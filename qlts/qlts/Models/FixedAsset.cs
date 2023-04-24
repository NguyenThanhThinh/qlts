using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using qlts.Enums;

namespace qlts.Models
{
    public class FixedAsset : BaseEntity
    {
        [StringLength ( 100 )]
        [Required]
        public string Code { get; set; }

        [StringLength ( 200 )]
        [Required] 
        public string Name { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public FixedAssetUnit Unit { get; set; }

        public string PartNumber { get; set; }

        public string SerialNumber { get; set; }

        public Guid FieldId { get; set; }

        public Field Field { get; set; }

        public Guid ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }


        public Guid FixedAssetStatusId { get; set; }
        public FixedAssetStatus FixedAssetStatus { get; set; }

        public DateTime FixedAssetDate { get; set; }

        public decimal Price { get; set; }

        public FixedAssetType FixedAssetType { get; set; }

        public Guid WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public string Note { get; set; }

    }
}