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
            _context.devicesEntities.Add(asset);
        }

        public void RemoveAsset(Asset asset)
        {
            _context.devicesEntities.Remove(asset);
        }

        public ICollection<Asset> GetAssets()
        {
            return _context.devicesEntities;
        }

        public Asset GetAssetById(Guid id)
        {
            return _context.devicesEntities.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Asset> GetAssetByUserId(Guid id)
        {
            return _context.devicesEntities.Where(x => x.Owners.Contains(id)).ToList();
        }

        public void UpdateAsset(Asset asset)
        {
            var index = _context.devicesEntities.ToList().FindIndex(x => x.Id == asset.Id);
            _context.devicesEntities[index] = asset;
        }

        public bool CheckIfAssetExist(Guid id)
        {
            return _context.devicesEntities.FirstOrDefault(x => x.Id == id) == null ? true : false;
        }
    }
}
