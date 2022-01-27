using System.Collections.Generic;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserAssetsOwnershipDto
    {
        public ShowUserDto User { get; set; }

        public ICollection<ShowUserAssetDto> Assets { get; set; }

        public ShowUserAssetsOwnershipDto()
        {
            this.Assets = new List<ShowUserAssetDto>();
        }
    }
}
