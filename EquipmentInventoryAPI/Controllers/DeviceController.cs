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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        // GET: api/Device
        [HttpGet]
        public async Task<ActionResult<ICollection<ShowDeviceDto>>> GetDevices()
        {
            var devices = _deviceRepository.GetDevices().ToList();
            var devicesDto = _mapper.Map<List<ShowDeviceDto>>(devices);

            for (int i = 0; i < devices.Count; i++)
            {
                devicesDto[i].Model = _mapper.Map<ShowDeviceModelDto>(devices[i].Model);
                devicesDto[i].Model.Manufacturer = _mapper.Map<ShowManufacturerDto>(devices[i].Model.Manufacturer);
                devicesDto[i].Owner = _mapper.Map<ShowUserDto>(devices[i].Owner);
            }

            return Ok(devicesDto);
        }

        // GET: api/Device/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowDeviceDto>> GetDevice(string id)
        {
            var device = _deviceRepository.GetDeviceById(Guid.Parse(id));

            if (device == null)
                return NotFound();

            var deviceDto = _mapper.Map<ShowDeviceDto>(device);
            deviceDto.Model = _mapper.Map<ShowDeviceModelDto>(device.Model);
            deviceDto.Model.Manufacturer = _mapper.Map<ShowManufacturerDto>(device.Model.Manufacturer);
            deviceDto.Owner = _mapper.Map<ShowUserDto>(device.Owner);

            return Ok(deviceDto);
        }

        // GET: api/Device/User/5
        [HttpGet("User/{id}")]
        public async Task<ActionResult<ICollection<ShowDeviceDto>>> GetDevicesByOwnerId(string id)
        {
            var userDevices = _deviceRepository.GetDevicesByUserId(Guid.Parse(id)).ToList();

            if (userDevices.Count() == 0)
                return NotFound();

            var devicesDto = _mapper.Map<ICollection<ShowDeviceDto>>(userDevices).ToList();

            for (int i = 0; i < userDevices.Count; i++)
            {
                devicesDto[i].Model = _mapper.Map<ShowDeviceModelDto>(userDevices[i].Model);
                devicesDto[i].Model.Manufacturer = _mapper.Map<ShowManufacturerDto>(userDevices[i].Model.Manufacturer);
                devicesDto[i].Owner = _mapper.Map<ShowUserDto>(userDevices[i].Owner);
            }

            return Ok(devicesDto);
        }

        // POST: api/Device
        [HttpPost]
        public async Task<ActionResult<ShowDeviceDto>> PostDevice(AddDeviceDto device)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newDevice = _mapper.Map<IDevice>(device);
            newDevice.Id = Guid.NewGuid();

            newDevice.Model = _mapper.Map<DeviceModel>(device.Model);
            newDevice.Model.Id = Guid.NewGuid();

            newDevice.Model.Manufacturer = _mapper.Map<Manufacturer>(device.Model.Manufacturer);
            newDevice.Model.Manufacturer.Id = Guid.NewGuid();

            newDevice.Owner = _mapper.Map<User>(device.Owner);

            _deviceRepository.AddDevice(newDevice);

            var deviceDto = _mapper.Map<ShowDeviceDto>(newDevice);
            deviceDto.Model = _mapper.Map<ShowDeviceModelDto>(newDevice.Model);
            deviceDto.Model.Manufacturer = _mapper.Map<ShowManufacturerDto>(newDevice.Model.Manufacturer);

            return CreatedAtAction("GetDevice", new { id = deviceDto.Id }, deviceDto);
        }

        // PUT: api/Device
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(string id, UpdateDeviceDto device)
        {
            if (Guid.Parse(id) != device.Id || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_deviceRepository.CheckIfDeviceExist(device.Id))
            {
                return NotFound();
            }
            else
            {
                var updatedDevice = _mapper.Map<IDevice>(device);
                updatedDevice.Model = _mapper.Map<DeviceModel>(device.Model);
                updatedDevice.Model.Manufacturer = _mapper.Map<Manufacturer>(device.Model.Manufacturer);
                updatedDevice.Owner = _mapper.Map<User>(device.Owner);

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
            return NoContent();
        }
    }
}
