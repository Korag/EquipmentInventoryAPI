using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.DbContext
{
    public class InMemoryContext
    {
        public readonly IList<IDevice> devicesEntities = new List<IDevice>();

        public InMemoryContext()
        {
            this.SeedInMemoryDatabase();
        }

        public void SeedInMemoryDatabase()
        {
            devicesEntities.Add(new Notebook()
            {
                Id = Guid.NewGuid(),
                SerialNumber = "ZXCZVGASG218",
                Name = "Test notebook",
                PresentPrice = 3200,
                PurchasePrice = 3500,
                PurchaseDate = System.DateTime.UtcNow,
                Model = new DeviceModel()
                {
                    Id = Guid.NewGuid(),
                    ModelNumber = "AXZCCASDAD123",
                    Manufacturer = new Manufacturer()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Comp123",
                        ContactNumber = "123456789",
                        EmailAddress = "comp@comp123.com",
                        Country = "Poland",
                        City = "XYZ",
                        Address = "Polna 1"
                    }
                }
            });
            devicesEntities.Add(new Notebook()
            {
                Id = Guid.NewGuid(),
                SerialNumber = "ZXCZVGAZG218",
                Name = "Test notebook 2",
                PresentPrice = 4200,
                PurchasePrice = 5500,
                PurchaseDate = System.DateTime.UtcNow,
                Model = new DeviceModel()
                {
                    Id = Guid.NewGuid(),
                    ModelNumber = "AXTTTASDAD123",
                    Manufacturer = new Manufacturer()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Asistek",
                        ContactNumber = "768593056",
                        EmailAddress = "contact@asistek.com",
                        Country = "USA",
                        City = "NYC",
                        Address = "Street A/20"
                    }
                }
            });;
        }
    }
}
