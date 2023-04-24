using System.Collections.Generic;

namespace qlts.ViewModels.AssetsTransfers
{
    public class CreateTransferViewModel :ViewModelBase
    {
        public string Note { get; set; }

        public string FixedAssetDate { get; set; }

        public string WarehouseId { get; set; }

        public List<string> AssetIds { get; set; }
    }
}