using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IUserAssetsOwnershipRepository
    {
        public void AddUserAssetOwnership(UserAssets userOwnership);
        public void RemoveUserAssetOwnership(UserAssets userOwnership);
        public ICollection<UserAssets> GetUserAssetsOwnership();
        public UserAssets GetUserAssetOwnershipById(Guid id);
        public UserAssets GetUserAssetOwnershipByUserId(Guid id);
        public void UpdateUserAssetOwnership(UserAssets userAsset);
    }
}
