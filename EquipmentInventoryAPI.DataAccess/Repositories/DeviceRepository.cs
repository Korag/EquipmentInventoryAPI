﻿using EquipmentInventoryAPI.DataAccess.DbContext;
using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentInventoryAPI.DataAccess.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private InMemoryContext _context { get; set; }

        public DeviceRepository(InMemoryContext context)
        {
            _context = context;
        }

        public void AddDevice(IDevice device)
        {
            _context.devicesEntities.Add(device);
        }

        public void RemoveDevice(IDevice device)
        {
            _context.devicesEntities.Remove(device);
        }

        public ICollection<IDevice> GetDevices()
        {
            return _context.devicesEntities;
        }

        public IDevice GetDeviceById(Guid id)
        {
            return _context.devicesEntities.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<IDevice> GetDevicesByUserId(Guid id)
        {
            return _context.devicesEntities.Where(x => x.Owners.Select(x => x.Id).Contains(id)).ToList();
        }

        public void UpdateDevice(IDevice device)
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
