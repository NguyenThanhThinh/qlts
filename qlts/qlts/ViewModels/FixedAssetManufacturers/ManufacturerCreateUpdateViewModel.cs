using qlts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.FixedAssetManufacturers
{
    public class FixedAssetManufacturerCreateUpdateViewModel : ViewModelBase
    {
        [Display(Name = "Hãng sản xuất")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public string DateFormatted { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public DateTime Date { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public string DateFormattedEdit { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }



        [Display(Name = "Ngày hết hạn")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public string WarrantyPeriodDateFormatted { get; set; } = DateTime.Now.AddMonths(12).ToString("dd/MM/yyyy");
        public DateTime WarrantyPeriodDate { get; set; }

        [Display(Name = "Ngày hết hạn")]
        public string WarrantyPeriodDateFormattedEdit { get; set; }


        [Display(Name = "Mã tài sản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string FixedAssetCode { get; set; }

        [Display(Name = "Tên tài sản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string FixedAssetName { get; set; }

        [Display(Name = "Mô tả tài sản")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Description { get; set; }

        [Display(Name = "Part Number")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string PartNumber { get; set; }

        [Display(Name = "Đơn vị tính")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 5, ErrorMessage = "Vui lòng chọn đơn vị tính")]
        public FixedAssetUnit Unit { get; set; }
    }
}