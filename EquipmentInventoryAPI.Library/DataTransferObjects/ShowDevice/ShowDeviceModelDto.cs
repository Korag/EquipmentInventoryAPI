using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowDeviceModelDto
    {
        public Guid Id { get; set; }
        public string ModelNumber { get; set; }

        public ShowManufacturerDto Manufacturer { get; set; }
    }
}
