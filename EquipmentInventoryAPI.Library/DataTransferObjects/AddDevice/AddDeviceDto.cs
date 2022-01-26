using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class AddDeviceDto
    {
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        public AddDeviceModelDto Model { get; set; }

        public ICollection<AddUserDto> Owners { get; set; }
    }
}
