using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public abstract class IDevice
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public string PurchasePrice { get; set; }
        public string PresentPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DeviceModel Model { get; set; } 
    }
}
