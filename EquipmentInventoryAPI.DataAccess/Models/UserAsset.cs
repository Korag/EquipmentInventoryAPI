using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserAsset
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset? DisposalDate { get; set; }
    }
}
