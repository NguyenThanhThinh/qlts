using qlts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

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


        [StringLength(100)]
        [Required]
        public string FixedAssetCode { get; set; }

        [StringLength(200)]
        [Required]
        public string FixedAssetName { get; set; }

        public string Description { get; set; }

        public string PartNumber { get; set; }

        public FixedAssetUnit Unit { get; set; }
    }
}