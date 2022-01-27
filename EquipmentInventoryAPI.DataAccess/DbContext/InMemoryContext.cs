using EquipmentInventoryAPI.DataAccess.Models;
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
                Type = AssetType.Notebook,
                PresentPrice = 3200,
                PurchasePrice = 3500,
                PurchaseDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(3000)),
                Owners = new List<Guid>()
                {
                   Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224")
                }
            });
            assetsSet.Add(new Asset()
            {
                Id = Guid.Parse("c379968b-4e44-40ac-a948-2abe3aefc054"),
                SerialNumber = "ZXCZVGAZG218",
                Name = "Test notebook 2",
                Type = AssetType.PC,
                PresentPrice = 4200,
                PurchasePrice = 5500,
                PurchaseDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2000)),
                Owners = new List<Guid>()
                {
                 Guid.Parse("c979968b-4e44-40ac-a948-2abe3aefc224")
                }
            });
            assetsSet.Add(new Asset()
            {
                Id = Guid.Parse("c179968b-4e44-40ac-a948-2abe3aefc054"),
                SerialNumber = "DGHASJGDJA",
                Name = "Test notebook 3",
                Type = AssetType.Printer,
                PresentPrice = 800,
                PurchasePrice = 2800,
                PurchaseDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2000)),
                Owners = new List<Guid>()
                {
                    Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224"),
                    Guid.Parse("c979968b-4e44-40ac-a948-2abe3aefc224")
                }
            });

            usersSet.Add(new User()
            {
                Id = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224"),
                FirstName = "Test",
                LastName = "User",
                EmailAddress = "test.user@email.com",
                ContactPhone = "123456789"
            });
            usersSet.Add(new User()
            {
                Id = Guid.Parse("c979968b-4e44-40ac-a948-2abe3aefc224"),
                FirstName = "Super",
                LastName = "User",
                EmailAddress = "super.user@email.com",
                ContactPhone = "987654321"
            });

            usersAssetsSet.Add(new UserAssetsOwnership()
            {
               UserId = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc224"),
               Assets = new List<UserAsset>()
               {
                   new UserAsset()
                   {
                       Id = Guid.NewGuid(),
                       AssetId = Guid.Parse("c579968b-4e44-40ac-a948-2abe3aefc054"),
                       AquireDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2500)),
                       DisposalDate = null
                   },
                   new UserAsset()
                   {
                       Id = Guid.NewGuid(),
                       AssetId = Guid.Parse("c179968b-4e44-40ac-a948-2abe3aefc054"),
                       AquireDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2000)),
                       DisposalDate = null
                   },
                    new UserAsset()
                   {
                       Id = Guid.NewGuid(),
                       AssetId = Guid.Parse("c379968b-4e44-40ac-a948-2abe3aefc054"),
                       AquireDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2000)),
                       DisposalDate =  DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1800)),
                   }
               }
            });

            usersAssetsSet.Add(new UserAssetsOwnership()
            {
                UserId = Guid.Parse("c979968b-4e44-40ac-a948-2abe3aefc224"),
                Assets = new List<UserAsset>()
               {
                   new UserAsset()
                   {
                       Id = Guid.NewGuid(),
                       AssetId = Guid.Parse("c179968b-4e44-40ac-a948-2abe3aefc054"),
                       AquireDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(2000)),
                       DisposalDate = null
                   },
                    new UserAsset()
                   {
                       Id = Guid.NewGuid(),
                       AssetId = Guid.Parse("c379968b-4e44-40ac-a948-2abe3aefc054"),
                       AquireDate = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1000)),
                       DisposalDate =  null,
                   }
               }
            });
        }
    }
}
