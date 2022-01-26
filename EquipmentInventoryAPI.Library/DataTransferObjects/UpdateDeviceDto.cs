﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentInventoryAPI.Library.DataTransferObjects
{
    public class UpdateDeviceDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }
        public decimal PresentPrice { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        public UpdateDeviceModelDto Model { get; set; }

        public UpdateDeviceDto()
        {

        }
    }
}
