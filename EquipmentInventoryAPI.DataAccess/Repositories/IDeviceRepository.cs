using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IDeviceRepository
    {
        public void AddDevice(IDevice device);
        public void RemoveDevice(IDevice device);
        public ICollection<IDevice> GetDevices();
        public IDevice GetDeviceById(Guid id);
        public ICollection<IDevice> GetDevicesByUserId(Guid id);
        public void UpdateDevice(IDevice device);
        bool CheckIfDeviceExist(Guid id);
    }
}
