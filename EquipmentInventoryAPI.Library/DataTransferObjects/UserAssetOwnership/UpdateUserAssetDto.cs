using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class UpdateUserAssetDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid AssetId { get; set; }

        [Required]
        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset? DisposalDate { get; set; }
    }
}
