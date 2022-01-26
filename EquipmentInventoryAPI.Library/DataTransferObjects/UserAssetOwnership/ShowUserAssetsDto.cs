using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserAssetsDto
    {
        public Guid UserId { get; set; }

        public ShowUserAssetOwnershipDto Devices { get; set; }
    }
}
