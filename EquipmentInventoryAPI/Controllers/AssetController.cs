using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.DataAccess.Repositories;
using EquipmentInventoryAPI.Library.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetRepository _deviceRepository;
        private readonly IUserAssetsOwnershipRepository _userOwnershipRepository;

        private readonly IMapper _mapper;

        public AssetController(IAssetRepository deviceRepository, 
                                IUserAssetsOwnershipRepository userOwnershipRepository, 
                                IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _userOwnershipRepository = userOwnershipRepository;
            _mapper = mapper;
        }

        // GET: api/Device
        [HttpGet]
        public async Task<ActionResult<ICollection<ShowAssetDto>>> GetDevices()
        {
            var devices = _deviceRepository.GetDevices().ToList();
            var devicesDto = _mapper.Map<List<ShowAssetDto>>(devices);

            return Ok(devicesDto);
        }

        // GET: api/Device/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowAssetDto>> GetDevice(string id)
        {
            var device = _deviceRepository.GetDeviceById(Guid.Parse(id));

            if (device == null)
                return NotFound();

            var deviceDto = _mapper.Map<ShowAssetDto>(device);

            return Ok(deviceDto);
        }

        // GET: api/Device/User/5
        [HttpGet("User/{id}")]
        public async Task<ActionResult<ICollection<ShowAssetDto>>> GetDevicesByOwnerId(string id)
        {
            var userDevices = _deviceRepository.GetDevicesByUserId(Guid.Parse(id)).ToList();

            if (userDevices.Count() == 0)
                return NotFound();

            var devicesDto = _mapper.Map<ICollection<ShowAssetDto>>(userDevices).ToList();

            return Ok(devicesDto);
        }

        //// GET: api/Device/History/User/5
        //[HttpGet("User/{id}")]
        //public async Task<ActionResult<ICollection<ShowUserDeviceDto>>> GetDevicesByOwnerId(string id)
        //{


        //}


        // POST: api/Device
        [HttpPost]
        public async Task<ActionResult<ShowAssetDto>> PostDevice(AddAssetDto device)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newDevice = _mapper.Map<Asset>(device);
            newDevice.Id = Guid.NewGuid();

            _deviceRepository.AddDevice(newDevice);

            foreach (var owner in newDevice.Owners)
            {
                var userDeviceOwnership = _mapper.Map<UserAssetOwnership>(newDevice);
                userDeviceOwnership.AquireDate = DateTime.Now;
                userDeviceOwnership.DisposalDate = DateTime.MinValue;

                var userOwnerShipInfo = _userOwnershipRepository.GetUserAssetOwnershipById(owner);

                if (userOwnerShipInfo == null)
                {
                    userOwnerShipInfo = new UserAssets();

                    userOwnerShipInfo.Id = Guid.NewGuid();
                    userOwnerShipInfo.OwnerId = owner;
                }

                userOwnerShipInfo.Assets.Add(userDeviceOwnership);
                _userOwnershipRepository.AddUserAssetOwnership(userOwnerShipInfo);
            }

            var deviceDto = _mapper.Map<ShowAssetDto>(newDevice);

            return CreatedAtAction("GetDevice", new { id = deviceDto.Id }, deviceDto);
        }

        // PUT: api/Device
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(string id, UpdateAssetDto device)
        {
            if (Guid.Parse(id) != device.Id || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_deviceRepository.CheckIfDeviceExist(device.Id))
            {
                return NotFound();
            }
            else
            {
                var updatedDevice = _mapper.Map<Asset>(device);
                _deviceRepository.UpdateDevice(updatedDevice);
            }

            return NoContent();
        }

        // DELETE: api/Device/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(string id)
        {
            var device = _deviceRepository.GetDeviceById(Guid.Parse(id));

            if (device == null)
                return NotFound();

            _deviceRepository.RemoveDevice(device);

            //foreach (var owner in device.Owners)
            //{
            //    var userOwnerShipInfo = _userOwnershipRepository.GetUserOwnershipInfoByUserId(owner.Id);

            //    if (userOwnerShipInfo != null)
            //    {
            //        if (userOwnerShipInfo.Devices.Select(x => x.Id).Contains(Guid.Parse(id)))
            //        {
            //            _userOwnershipRepository.
            //        }
            //    }
            //}

            return NoContent();
        }
    }
}
