using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.Library.DataTransferObjects;

namespace EquipmentInventoryAPI.Library.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IDevice, ShowDeviceDto>();
            CreateMap<Manufacturer, ShowManufacturerDto>();
            CreateMap<DeviceModel, ShowDeviceModelDto>();

            CreateMap<IDevice, AddDeviceDto>();
            CreateMap<AddDeviceDto, IDevice>();

            CreateMap<Manufacturer, AddManufacturerDto>();
            CreateMap<DeviceModel, AddDeviceModelDto>();

            CreateMap<AddManufacturerDto, Manufacturer>();
            CreateMap<AddDeviceModelDto, DeviceModel>();

            CreateMap<UpdateDeviceDto, IDevice>();
            CreateMap<UpdateManufacturerDto, Manufacturer>();
            CreateMap<UpdateDeviceModelDto, DeviceModel>();

            CreateMap<AddUserDto, User>();
            CreateMap<User, ShowUserDto>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<IDevice, UserDeviceOwnership>();
        }
    }
}
