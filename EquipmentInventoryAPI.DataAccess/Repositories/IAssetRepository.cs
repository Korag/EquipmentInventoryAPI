using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IAssetRepository
    {
        public void AddDevice(Asset device);
        public void RemoveDevice(Asset device);
        public ICollection<Asset> GetDevices();
        public Asset GetDeviceById(Guid id);
        public ICollection<Asset> GetDevicesByUserId(Guid id);
        public void UpdateDevice(Asset device);
        bool CheckIfDeviceExist(Guid id);
    }
}
