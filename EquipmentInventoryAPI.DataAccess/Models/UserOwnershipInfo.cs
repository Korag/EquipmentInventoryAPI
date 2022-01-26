using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserOwnershipInfo
    {
        public Guid Id { get; set; }

        public User Owner { get; set; }

        public ICollection<UserDeviceOwnership> Devices { get; set; }

        public UserOwnershipInfo()
        {
            this.Devices = new List<UserDeviceOwnership>();
        }
    }
}
