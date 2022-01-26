using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserDeviceDto
    {
        public Guid UserId { get; set; }

        public DeviceOwnershipDto Devices { get; set; }
    }
}
