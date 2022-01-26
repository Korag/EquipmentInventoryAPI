using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.Library.DataTransferObjects;

namespace EquipmentInventoryAPI.Library.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Asset, ShowAssetDto>();
            CreateMap<Manufacturer, ShowManufacturerDto>();
            CreateMap<DeviceModel, ShowDeviceModelDto>();

            CreateMap<Asset, AddAssetDto>();
            CreateMap<AddAssetDto, Asset>();

            CreateMap<Manufacturer, AddManufacturerDto>();
            CreateMap<DeviceModel, AddDeviceModelDto>();

            CreateMap<AddManufacturerDto, Manufacturer>();
            CreateMap<AddDeviceModelDto, DeviceModel>();

            CreateMap<UpdateAssetDto, Asset>();
            CreateMap<UpdateManufacturerDto, Manufacturer>();
            CreateMap<UpdateDeviceModelDto, DeviceModel>();

            CreateMap<AddUserDto, User>();
            CreateMap<User, ShowUserDto>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Asset, UserAssetOwnership>();
        }
    }
}
