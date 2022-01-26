using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserDeviceOwnership
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }

        public DateTimeOffset PurchaseDate { get; set; }

        public DeviceModel Model { get; set; }

        public DateTimeOffset AquireDate { get; set; }
        public DateTimeOffset DisposalDate { get; set; }
    }
}
