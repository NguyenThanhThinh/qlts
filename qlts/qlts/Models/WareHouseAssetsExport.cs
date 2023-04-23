using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
 
    public class WareHouseAssetsExport : BaseEntity
    {
        public string FixedAssetId { get; set; }

        public FixedAsset FixedAsset { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public Guid? WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}