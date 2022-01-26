using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public void RemoveUser(User user);
        public ICollection<User> GetUsers();
        public User GetUserById(Guid id);
        public void UpdateUser(User user);
        public bool CheckIfUserExist(Guid id);
    }
}