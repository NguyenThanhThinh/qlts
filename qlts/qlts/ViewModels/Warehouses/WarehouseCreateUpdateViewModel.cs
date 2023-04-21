using qlts.Enums;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Warehouses
{
    public class WarehouseCreateUpdateViewModel : ViewModelBase
    {
        [Display(Name = "Tên kho")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Trung tâm")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 3, ErrorMessage = "Vui lòng chọn trung tâm")]
        public CenterUnit Center { get; set; }

        [Display(Name = "Đơn vị")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Unit { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(500, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Address { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }

        [Display(Name = "Loại kho")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [Range(1, 5, ErrorMessage = "Vui lòng chọn loại kho")]
        public WarehouseType WarehouseType { get; set; }
    }
}