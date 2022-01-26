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
                Id = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc054"),
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
                },
                Owner = new User()
                {
                    Id = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224"),
                    FirstName = "Test",
                    LastName = "User"
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
                },
                Owner = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User",
                    LastName = "Second"
                }
            });;
            devicesEntities.Add(new Notebook()
            {
                Id = Guid.NewGuid(),
                SerialNumber = "DGHASJGDJA",
                Name = "Test notebook 3",
                PresentPrice = 800,
                PurchasePrice = 2800,
                PurchaseDate = System.DateTime.UtcNow,
                Model = new DeviceModel()
                {
                    Id = Guid.NewGuid(),
                    ModelNumber = "HHAGSHFAGT",
                    Manufacturer = new Manufacturer()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Thortn",
                        ContactNumber = "763812390",
                        EmailAddress = "contact@thornt.com",
                        Country = "Germany",
                        City = "Hannover",
                        Address = "Strase20"
                    }
                },
                Owner = new User()
                {
                    Id = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224"),
                    FirstName = "Test",
                    LastName = "User"
                }
            }); ;
        }
    }
}
