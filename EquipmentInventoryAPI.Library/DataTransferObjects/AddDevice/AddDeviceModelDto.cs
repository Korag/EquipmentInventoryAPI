using System.ComponentModel.DataAnnotations;

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
