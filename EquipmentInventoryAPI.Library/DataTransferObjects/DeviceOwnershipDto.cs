using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class DeviceOwnershipDto
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }


        public ShowDeviceModelDto Model { get; set; }

        public DeviceOwnershipDto()
        {

        }
    }
}
