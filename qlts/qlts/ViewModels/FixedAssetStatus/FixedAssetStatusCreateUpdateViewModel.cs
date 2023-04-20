using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.FixedAssetStatus
{
    public class FixedAssetStatusCreateUpdateViewModel :ViewModelBase
    {
        [Display(Name = "Tên tình trạng")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }
    }
}