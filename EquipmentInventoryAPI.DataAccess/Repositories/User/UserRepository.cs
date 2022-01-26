using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private InMemoryContext _context { get; set; }

        public UserRepository(InMemoryContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.usersSet.Add(user);
        }

        public void RemoveUser(User user)
        {
            _context.usersSet.Remove(user);
        }

        public ICollection<User> GetUsers()
        {
            return _context.usersSet;
        }

        public User GetUserById(Guid id)
        {
            return _context.usersSet.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(User user)
        {
            var index = _context.usersSet.ToList().FindIndex(x => x.Id == user.Id);
            _context.usersSet[index] = user;
        }

        public bool CheckIfUserExist(Guid id)
        {
            return _context.usersSet.FirstOrDefault(x => x.Id == id) != null ? true : false;
        }
    }
}
