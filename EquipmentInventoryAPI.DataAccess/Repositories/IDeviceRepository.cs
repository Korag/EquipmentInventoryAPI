using EquipmentInventoryAPI.DataAccess.Models;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public interface IDeviceRepository
    {
        public void AddDevice(IDevice device);
        public void RemoveDevice(IDevice device);
        public ICollection<IDevice> GetDevices();
        public IDevice GetDeviceById(int id);
        public void UpdateDevice(IDevice device);
    }
}
