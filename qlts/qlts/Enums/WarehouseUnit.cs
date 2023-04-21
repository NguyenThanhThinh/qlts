using System.ComponentModel.DataAnnotations;

namespace qlts.Enums
{
    public enum WarehouseUnit
    {
        [Display(Name = "P.KTTC")]
        KTTC = 1,
        [Display(Name = "Đ.HNI")]
        HNI = 2,
        [Display(Name = "Đ.HPG")]
        HPG = 3,
        [Display(Name = "Đ.SLA")]
        SLA = 4,
        [Display(Name = "Đ.HCM")]
        HCM = 5,
        [Display(Name = "Đ.CTO")]
        CTO = 6,
        [Display(Name = "Đ.PRA")]
        PRA = 7,
        [Display(Name = "Đ.DNG")]
        DNG = 8,
        [Display(Name = "Đ.QNN")]
        QNN = 9,
        [Display(Name = "Đ.NTG")]
        NTG = 10
    }
}