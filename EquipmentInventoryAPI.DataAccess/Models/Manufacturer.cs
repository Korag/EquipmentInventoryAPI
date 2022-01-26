using System;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class Manufacturer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Manufacturer()
        {

        }
    }
}
