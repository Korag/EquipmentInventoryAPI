using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserAssets
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }

        public ICollection<UserAssetOwnership> Assets { get; set; }

        public UserAssets()
        {
            this.Assets = new List<UserAssetOwnership>();
        }
    }
}
