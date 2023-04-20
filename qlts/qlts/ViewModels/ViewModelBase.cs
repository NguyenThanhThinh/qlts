using System;

namespace qlts.ViewModels
{
    public class ViewModelBase
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedBy { get; set; }
        public const string ErrorMessageRequired = "{0} không được trống";
        public const string ErrorMessageMaxLength = "{0} phải nhỏ hơn {1} ký tự";
        public const string ErrorMessageStringLength = "{0} phải từ {2} tới {1} ký tự";
    }
}