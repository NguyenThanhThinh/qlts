using System;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Manufacturers
{
    public class ManufacturerIndexViewModel : ViewModelBase
    {
        [Display(Name = "Hãng sản xuất")]

        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]

        public DateTime? Date { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}