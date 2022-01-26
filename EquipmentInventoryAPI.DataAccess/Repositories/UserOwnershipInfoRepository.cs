using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public class UserOwnershipInfoRepository : IUserOwnershipInfoRepository
    {
        private InMemoryContext _context { get; set; }

        public UserOwnershipInfoRepository(InMemoryContext context)
        {
            _context = context;
        }

        public void AddUserDeviceOwnership(UserOwnershipInfo userOwnership)
        {
            _context.usersDevicesEntities.Add(userOwnership);
        }

        public void RemoveUserDeviceOwnership(UserOwnershipInfo userOwnership)
        {
            _context.usersDevicesEntities.Remove(userOwnership);
        }

        public ICollection<UserOwnershipInfo> GetUserOwnershipInfo()
        {
            return _context.usersDevicesEntities;
        }

        public UserOwnershipInfo GetUserOwnershipInfoById(Guid id)
        {
            return _context.usersDevicesEntities.FirstOrDefault(x => x.Id == id);
        }

        public UserOwnershipInfo GetUserOwnershipInfoByUserId(Guid id)
        {
            return _context.usersDevicesEntities.FirstOrDefault(x => x.Owner.Id == id);
        }

        public void UpdateUserOwnershipInfo(UserOwnershipInfo userOwnershipInfo)
        {
            var index = _context.usersDevicesEntities.ToList().FindIndex(x => x.Id == userOwnershipInfo.Id);
            _context.usersDevicesEntities[index] = userOwnershipInfo;
        }
    }
}
