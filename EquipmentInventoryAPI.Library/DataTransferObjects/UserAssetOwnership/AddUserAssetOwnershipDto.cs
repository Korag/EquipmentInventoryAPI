using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class AddUserAssetOwnershipDto
    {
        public Guid UserId { get; set; }

        public AddUserAssetDto Asset { get; set; }

        public AddUserAssetOwnershipDto()
        {

        }
    }
}
