using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IAssetRepository
    {
        public void AddAsset(Asset device);
        public void RemoveAsset(Asset device);
        public ICollection<Asset> GetAssets();
        public Asset GetAssetById(Guid id);
        public ICollection<Asset> GetAssetByUserId(Guid id);
        public void UpdateAsset(Asset device);
        bool CheckIfAssetExist(Guid id);
    }
}
