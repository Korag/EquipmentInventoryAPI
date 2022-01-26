using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserAssetDto
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset? DisposalDate { get; set; }

        public ShowUserAssetDto()
        {

        }
    }
}
