using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserAssetOwnershipDto
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset DisposalDate { get; set; }

        public ShowUserAssetOwnershipDto()
        {

        }
    }
}
