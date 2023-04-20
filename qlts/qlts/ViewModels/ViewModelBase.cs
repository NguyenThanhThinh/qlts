using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace qlts.ViewModels
{
    public class ViewModelBase
    {
        public Guid Id { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Display(Name = "Người cập nhật")]
        public DateTime? ModifiedBy { get; set; }
        public const string ErrorMessageRequired = "{0} không được trống";
        public const string ErrorMessageMaxLength = "{0} phải nhỏ hơn {1} ký tự";
        public const string ErrorMessageStringLength = "{0} phải từ {2} tới {1} ký tự";
    }
}