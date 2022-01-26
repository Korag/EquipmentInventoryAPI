using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class IDevice
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DeviceModel Model { get; set; }

        public IDevice()
        {

        }
    }
}
