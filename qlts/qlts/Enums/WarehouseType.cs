using System.ComponentModel.DataAnnotations;

namespace qlts.Enums
{
    public enum WarehouseType
    {
        [Display(Name = "Mua mới")]
        MM = 1,
        [Display(Name = "Thu hồi")]
        TH = 2,
        [Display(Name = "Bảo hành")]
        BH = 3,
        [Display(Name = "Sửa chữa")]
        SC = 4,
        [Display(Name = "Thanh lý")]
        TL = 5,
        [Display(Name = "Dự phòng")]
        DP = 6

    }
}