using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qlts.ViewModels.Fields
{
    public class FieldCreateUpdateViewModel : ViewModelBase
    {
        [Display(Name = "Tên lĩnh vực")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }
    }
}