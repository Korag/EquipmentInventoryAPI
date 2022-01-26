using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public class UserAssetsOwnershipRepository : IUserAssetsOwnershipRepository
    {
        private InMemoryContext _context { get; set; }

        public UserAssetsOwnershipRepository(InMemoryContext context)
        {
            _context = context;
        }

        public void AddUserAssetOwnership(UserAssets userOwnership)
        {
            _context.usersDevicesEntities.Add(userOwnership);
        }

        public void RemoveUserAssetOwnership(UserAssets userOwnership)
        {
            _context.usersDevicesEntities.Remove(userOwnership);
        }

        public ICollection<UserAssets> GetUserAssetsOwnership()
        {
            return _context.usersDevicesEntities;
        }

        public UserAssets GetUserAssetOwnershipById(Guid id)
        {
            return _context.usersDevicesEntities.FirstOrDefault(x => x.Id == id);
        }

        public UserAssets GetUserAssetOwnershipByUserId(Guid id)
        {
            return _context.usersDevicesEntities.FirstOrDefault(x => x.OwnerId == id);
        }

        public void UpdateUserAssetOwnership(UserAssets userAsset)
        {
            var index = _context.usersDevicesEntities.ToList().FindIndex(x => x.Id == userAsset.Id);
            _context.usersDevicesEntities[index] = userAsset;
        }
    }
}
