using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserOwnershipInfo
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }

        public ICollection<Guid> Devices { get; set; }

        public UserOwnershipInfo()
        {
            this.Devices = new List<Guid>();
        }
    }
}
