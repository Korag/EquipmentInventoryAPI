using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class AddUserAssetDto
    {
        [Required]
        public Guid AssetId { get; set; }

        [Required]
        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset? DisposalDate { get; set; }
    }
}
