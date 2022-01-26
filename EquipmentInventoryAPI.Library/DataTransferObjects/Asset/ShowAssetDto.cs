using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowAssetDto
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        public AssetType Type { get; set; }

        public ICollection<Guid> Owners { get; set; }

        public ShowAssetDto()
        {

        }
    }
}
