using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDeviceOwnershipController : ControllerBase
    {
        private readonly IUserAssetsOwnershipRepository _userOwnershipRepository;

        private readonly IMapper _mapper;

        public UserDeviceOwnershipController(IMapper mapper, IUserAssetsOwnershipRepository userOwnershipRepository)
        {
            _mapper = mapper;
            _userOwnershipRepository = userOwnershipRepository;
        }

        //// GET: api/Device
        //[HttpGet]
        //public async Task<ActionResult<ICollection<ShowDeviceDto>>> GetDevices()
        //{
        //    var devices = _deviceRepository.GetDevices().ToList();
        //    var devicesDto = _mapper.Map<List<ShowDeviceDto>>(devices);

        //    for (int i = 0; i < devices.Count; i++)
        //    {
        //        devicesDto[i].Model = _mapper.Map<ShowDeviceModelDto>(devices[i].Model);
        //        devicesDto[i].Model.Manufacturer = _mapper.Map<ShowManufacturerDto>(devices[i].Model.Manufacturer);
        //        devicesDto[i].Owners = _mapper.Map<ICollection<ShowUserDto>>(devices[i].Owners);
        //    }

        //    return Ok(devicesDto);
        //}
    }
}
