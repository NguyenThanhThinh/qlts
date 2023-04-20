using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Roles
{
    public class RoleCreateUpdateViewModel : ViewModelBase
    {
        [Display(Name = "Tên quyền")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(20, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Description { get; set; }
    }
}