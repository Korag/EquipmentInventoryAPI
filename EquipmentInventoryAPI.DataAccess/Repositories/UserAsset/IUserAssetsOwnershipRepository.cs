using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IUserAssetsOwnershipRepository
    {
        public void AddUserAssetOwnership(UserAssetsOwnership userOwnership);
        public void RemoveUserAssetOwnership(UserAssetsOwnership userOwnership);
        public ICollection<UserAssetsOwnership> GetUserAssetsOwnership();
        public UserAssetsOwnership GetUserAssetOwnershipByUserId(Guid id);
        public void UpdateUserAssetOwnership(UserAssetsOwnership userAsset);
        public bool CheckIfUserAssetOwnershipExist(Guid id);
    }
}
