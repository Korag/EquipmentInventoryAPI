﻿using EquipmentInventoryAPI.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.DbContext
{
    public class InMemoryContext
    {
        public readonly IList<Asset> assetsSet = new List<Asset>();
        public readonly IList<UserAssetsOwnership> usersAssetsSet = new List<UserAssetsOwnership>();
        public readonly IList<User> usersSet = new List<User>();

        public InMemoryContext()
        {
            this.SeedInMemoryDatabase();
        }

        public void SeedInMemoryDatabase()
        {
            assetsSet.Add(new Asset()
            {
                Id = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc054"),
                SerialNumber = "ZXCZVGASG218",
                Name = "Test notebook",
                PresentPrice = 3200,
                PurchasePrice = 3500,
                PurchaseDate = DateTimeOffset.UtcNow,
                Owners = new List<Guid>()
                {
                   Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224")
                }
            }); ;
            assetsSet.Add(new Asset()
            {
                Id = Guid.NewGuid(),
                SerialNumber = "ZXCZVGAZG218",
                Name = "Test notebook 2",
                PresentPrice = 4200,
                PurchasePrice = 5500,
                PurchaseDate = DateTimeOffset.UtcNow,
                Owners = new List<Guid>()
                {
                 Guid.Parse("c979968b-4e44-40ac-a948-2abe3aefc224")
                }
            });
            assetsSet.Add(new Asset()
            {
                Id = Guid.NewGuid(),
                SerialNumber = "DGHASJGDJA",
                Name = "Test notebook 3",
                PresentPrice = 800,
                PurchasePrice = 2800,
                PurchaseDate = DateTimeOffset.UtcNow,
                Owners = new List<Guid>()
                {
                    Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224"),
                    Guid.Parse("c979968b-4e44-40ac-a948-2abe3aefc224")
                }
            });
        }
    }
}
