using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class AddAssetDto
    {
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        [Required]
        public AssetType Type { get; set; }

        [Required]
        public DateTimeOffset PurchaseDate { get; set; }

        public ICollection<Guid> Owners { get; set; }
    }
}
