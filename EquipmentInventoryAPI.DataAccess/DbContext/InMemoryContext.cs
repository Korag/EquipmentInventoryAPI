using EquipmentInventoryAPI.DataAccess.Models;
using System.Collections.Generic;

namespace EquipmentInventoryAPI.DataAccess.DbContext
{
    public class InMemoryContext
    {
        public readonly IList<IDevice> devicesEntities = new List<IDevice>();

        public InMemoryContext()
        {

        }
    }
}
