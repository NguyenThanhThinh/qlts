using System;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Manufacturers
{
    public class ManufacturerIndexViewModel : ViewModelBase
    {
        [Display(Name = "Hãng sản xuất")]

        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public string DateFormatted => Date.ToString("dd/MM/yyyy");
        public DateTime Date { get; set; }

       

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "Ngày hết hạn")]
        public string WarrantyPeriodDateFormatted => WarrantyPeriodDate.ToString("dd/MM/yyyy");
        public DateTime WarrantyPeriodDate { get; set; }
    }
}