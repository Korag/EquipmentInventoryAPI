using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class UpdateUserAssetsOwnershipDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public ICollection<UpdateUserAssetDto> Assets { get; set; }

        public UpdateUserAssetsOwnershipDto()
        {

        }
    }
}
