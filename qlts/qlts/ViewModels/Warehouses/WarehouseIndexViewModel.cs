using qlts.Enums;
using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Warehouses
{
    public class WarehouseIndexViewModel :ViewModelBase
    {
        [Display(Name = "Tên kho")]
       
        public string Name { get; set; }

        [Display(Name = "Trung tâm")]
        
        public CenterUnit Center { get; set; }

        [Display(Name = "Đơn vị")]
   
        public string Unit { get; set; }

        [Display(Name = "Địa chỉ")]

        public string Address { get; set; }

        [Display(Name = "Ghi chú")]

        public string Note { get; set; }
    }
}