using System;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Manufacturers
{
    public class ManufacturerCreateUpdateViewModel : ViewModelBase
    {
        [Display(Name = "Hãng sản xuất")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]
        [Required(ErrorMessage = ErrorMessageRequired)]
        public string DateFormatted { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public DateTime? Date { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public string DateFormattedEdit { get; set; }

        [Display(Name = "Ghi chú")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = ErrorMessageStringLength)]
        public string Note { get; set; }
    }
}