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

        public void AddDevice(Asset device)
        {
            _context.devicesEntities.Add(device);
        }

        public void RemoveDevice(Asset device)
        {
            _context.devicesEntities.Remove(device);
        }

        public ICollection<Asset> GetDevices()
        {
            return _context.devicesEntities;
        }

        public Asset GetDeviceById(Guid id)
        {
            return _context.devicesEntities.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Asset> GetDevicesByUserId(Guid id)
        {
            return _context.devicesEntities.Where(x => x.Owners.Contains(id)).ToList();
        }

        public void UpdateDevice(Asset device)
        {
            var index = _context.devicesEntities.ToList().FindIndex(x => x.Id == device.Id);
            _context.devicesEntities[index] = device;
        }

        public bool CheckIfDeviceExist(Guid id)
        {
            return _context.devicesEntities.FirstOrDefault(x => x.Id == id) == null ? true : false;
        }
    }
}
