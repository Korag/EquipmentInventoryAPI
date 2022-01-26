using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class AddDeviceModelDto
    {
        [Required]
        public string ModelNumber { get; set; }

        public AddManufacturerDto Manufacturer { get; set; }

        public AddDeviceModelDto()
        {

        }
    }
}
