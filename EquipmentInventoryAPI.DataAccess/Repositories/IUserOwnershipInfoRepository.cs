using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IUserOwnershipInfoRepository
    {
        public void AddUserDeviceOwnership(UserOwnershipInfo userOwnership);

        public void RemoveUserDeviceOwnership(UserOwnershipInfo userOwnership);
        public ICollection<UserOwnershipInfo> GetUserOwnershipInfo();
        public UserOwnershipInfo GetUserOwnershipInfoById(Guid id);
        public UserOwnershipInfo GetUserOwnershipInfoByUserId(Guid id);
        public void UpdateUserOwnershipInfo(UserOwnershipInfo userOwnershipInfo);
    }
}
