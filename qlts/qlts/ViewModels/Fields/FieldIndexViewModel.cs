using System.ComponentModel.DataAnnotations;

namespace qlts.ViewModels.Fields
{
    public class FieldIndexViewModel : ViewModelBase
    {
        [Display(Name = "Tên lĩnh vực")]
       
        public string Name { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}