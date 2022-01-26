using System;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class ShowUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ShowUserDto()
        {

        }
    }
}
