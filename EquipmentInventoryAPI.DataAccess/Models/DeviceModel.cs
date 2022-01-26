using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class DeviceModel
    {
        public Guid Id { get; set; }
        public string ModelNumber { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public DeviceModel()
        {

        }
    }
}
