using System;
using System.ComponentModel.DataAnnotations;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class DisposeUserAssetOwnershipDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid UserAssetId { get; set; }

        public DisposeUserAssetOwnershipDto()
        {

        }
    }
}
