using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class DeviceModel
    {
        public Guid Id { get; set; }
        public string ModelNumber { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public DeviceModel()
        {

        }
    }
}
