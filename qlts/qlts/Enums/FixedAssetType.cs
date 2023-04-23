using System.ComponentModel.DataAnnotations;

namespace qlts.Enums
{
    public enum FixedAssetType
    {
        [Display(Name = "Thanh lý")]
        LiquidationAsset = 1,
        [Display(Name = "Nhập")]
        UseAsset = 2,
        [Display(Name = "Điều chuyển")]
        AssetsTransfer = 3,
        [Display(Name = "Xuất")]
        AssetsExport = 4
    }
}