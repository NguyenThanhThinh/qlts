using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
    [Table("TBL_FixedAssets")]
    public class FixedAsset : BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Code { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string PartNumber { get; set; }

        public string SerialNumber { get; set; }

        public int FieldId { get; set; }

        public Field Field { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public DateTime? DatePurchase { get; set; }

        public int FixedAssetStatusId { get; set; }
        public FixedAssetStatus FixedAssetStatus { get; set; }

        public DateTime? FixedAssetDate { get; set; }


    }
}