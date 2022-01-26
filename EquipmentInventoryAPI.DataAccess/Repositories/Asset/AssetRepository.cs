using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private InMemoryContext _context { get; set; }

        public AssetRepository(InMemoryContext context)
        {
            _context = context;
        }

        public void AddAsset(Asset asset)
        {
            _context.assetsSet.Add(asset);
        }

        public void RemoveAsset(Asset asset)
        {
            _context.assetsSet.Remove(asset);
        }

        public ICollection<Asset> GetAssets()
        {
            return _context.assetsSet;
        }

        public Asset GetAssetById(Guid id)
        {
            return _context.assetsSet.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Asset> GetAssetByUserId(Guid id)
        {
            return _context.assetsSet.Where(x => x.Owners.Contains(id)).ToList();
        }

        public void UpdateAsset(Asset asset)
        {
            var index = _context.assetsSet.ToList().FindIndex(x => x.Id == asset.Id);
            _context.assetsSet[index] = asset;
        }

        public bool CheckIfAssetExist(Guid id)
        {
            return _context.assetsSet.FirstOrDefault(x => x.Id == id) != null ? true : false;
        }
    }
}
