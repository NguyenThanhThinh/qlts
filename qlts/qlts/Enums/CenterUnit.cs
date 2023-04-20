using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace qlts.Enums
{
    public enum CenterUnit
    {
        [Display(Name = "NET1")]
        N1 = 1,
        [Display(Name = "NET2")]
        N2 = 2,
        [Display(Name = "NET3")]
        N3 = 3
    }
}