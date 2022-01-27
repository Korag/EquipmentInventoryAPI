using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class AddUserAssetOwnershipDto
    {
        public Guid UserId { get; set; }

        public AddUserAssetDto Asset { get; set; }

        public AddUserAssetOwnershipDto()
        {

        }
    }
}
