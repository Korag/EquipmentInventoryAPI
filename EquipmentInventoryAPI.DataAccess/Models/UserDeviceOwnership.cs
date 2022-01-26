using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserDeviceOwnership
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DeviceModel Model { get; set; }

        public DateTime AquireDate { get; set; }
        public DateTime DisposalDate { get; set; }
    }
}
