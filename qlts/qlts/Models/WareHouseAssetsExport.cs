using System;

namespace qlts.Models
{
    public class WareHouseAssetsExport : BaseEntity
    {
        public int FixedAssetId { get; set; }

        public FixedAsset FixedAsset { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

    }
}