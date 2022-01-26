using System;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.Models
{
    public class UserAssetsOwnership
    {
        public Guid UserId { get; set; }

        public ICollection<UserAsset> Assets { get; set; }

        public UserAssetsOwnership()
        {

        }
    }
}
