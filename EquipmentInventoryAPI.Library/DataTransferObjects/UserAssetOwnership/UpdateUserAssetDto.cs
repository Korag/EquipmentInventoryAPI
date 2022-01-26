using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
