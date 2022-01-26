using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class UpdateDeviceModelDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string ModelNumber { get; set; }

        public UpdateManufacturerDto Manufacturer { get; set; }

        public UpdateDeviceModelDto()
        {

        }
    }
}
