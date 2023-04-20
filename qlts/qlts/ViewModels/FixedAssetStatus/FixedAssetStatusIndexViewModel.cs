using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace qlts.ViewModels.FixedAssetStatus
{
    public class FixedAssetStatusIndexViewModel :ViewModelBase
    {
        [Display(Name = "Tên tình trạng")]
      
        public string Name { get; set; }

        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
    }
}