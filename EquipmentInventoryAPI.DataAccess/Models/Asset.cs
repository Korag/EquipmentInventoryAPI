using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        public DateTimeOffset PurchaseDate { get; set; }

        public AssetType Type { get; set; }

        public ICollection<Guid> Owners { get; set; }

        public Asset()
        {

        }
    }
}
