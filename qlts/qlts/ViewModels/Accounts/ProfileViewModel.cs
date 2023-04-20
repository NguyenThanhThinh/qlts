
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Accounts
{
    public class ProfileViewModel : ViewModelBase
    {
        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Password { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}