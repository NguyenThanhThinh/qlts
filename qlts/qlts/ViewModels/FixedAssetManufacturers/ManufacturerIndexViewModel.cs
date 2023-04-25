using qlts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.FixedAssetManufacturers
{
    public class FixedAssetManufacturerIndexViewModel : ViewModelBase
    {
        [Display(Name = "Hãng sản xuất")]

        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public string DateFormatted => Date.ToString("dd/MM/yyyy");
        public DateTime Date { get; set; }

       

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Ngày hết hạn")]
        public string WarrantyPeriodDateFormatted => WarrantyPeriodDate.ToString("dd/MM/yyyy");
        public DateTime WarrantyPeriodDate { get; set; }


        [Display(Name = "Mã tài sản")]
        public string FixedAssetCode { get; set; }

        [Display(Name = "Tên tài sản")]
        public string FixedAssetName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Part Number")]
        public string PartNumber { get; set; }

        [Display(Name = "Đơn vị")]
        public FixedAssetUnit Unit { get; set; }
    }
}