﻿using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {

        }
    }
}
