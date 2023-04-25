﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
 
    public class FixedAssetManufacturer : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public DateTime WarrantyPeriodDate { get; set; }
    }
}