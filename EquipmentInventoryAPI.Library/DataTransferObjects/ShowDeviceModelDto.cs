using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowDeviceModelDto
    {
        public Guid Id { get; set; }
        public string ModelNumber { get; set; }

        public ShowManufacturerDto Manufacturer { get; set; }
    }
}
