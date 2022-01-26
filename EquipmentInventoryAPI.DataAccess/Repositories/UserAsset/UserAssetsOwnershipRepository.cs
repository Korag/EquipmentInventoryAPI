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

        public void AddUserAssetOwnership(UserAssetsOwnership userOwnership)
        {
            _context.usersAssetsSet.Add(userOwnership);
        }

        public void RemoveUserAssetOwnership(UserAssetsOwnership userOwnership)
        {
            _context.usersAssetsSet.Remove(userOwnership);
        }

        public ICollection<UserAssetsOwnership> GetUserAssetsOwnership()
        {
            return _context.usersAssetsSet;
        }

        public UserAssetsOwnership GetUserAssetOwnershipByUserId(Guid id)
        {
            return _context.usersAssetsSet.FirstOrDefault(x => x.UserId == id);
        }

        public void UpdateUserAssetOwnership(UserAssetsOwnership userAsset)
        {
            var index = _context.usersAssetsSet.ToList().FindIndex(x => x.UserId == userAsset.UserId);
            _context.usersAssetsSet[index] = userAsset;
        }

        public bool CheckIfUserAssetOwnershipExist(Guid id)
        {
            return _context.usersAssetsSet.FirstOrDefault(x => x.UserId == id) != null ? true : false;
        }
    }
}
