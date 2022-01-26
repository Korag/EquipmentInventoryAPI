using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowDeviceDto
    {
        public ShowDeviceDto()
        {

        }

        public Guid Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        public ShowDeviceModelDto Model { get; set; }
    }
}
