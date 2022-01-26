using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserAssetsOwnershipDto
    {
        public Guid UserId { get; set; }

        public ICollection<ShowUserAssetDto> Assets { get; set; }
    }
}
