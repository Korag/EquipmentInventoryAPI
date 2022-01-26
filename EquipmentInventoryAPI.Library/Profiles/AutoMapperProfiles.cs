﻿using AutoMapper;
using EquipmentInventoryAPI.DataAccess.Models;
using EquipmentInventoryAPI.Library.DataTransferObjects;

namespace EquipmentInventoryAPI.Library.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Asset, ShowAssetDto>();
            CreateMap<Asset, AddAssetDto>();
            CreateMap<AddAssetDto, Asset>();
            CreateMap<UpdateAssetDto, Asset>();

            CreateMap<AddUserDto, User>();
            CreateMap<User, ShowUserDto>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Asset, UserAssetOwnership>();
        }
    }
}
