using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserAssetOwnership
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset DisposalDate { get; set; }
    }
}
