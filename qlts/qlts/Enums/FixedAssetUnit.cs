using System.ComponentModel.DataAnnotations;

namespace qlts.Enums
{
    public enum FixedAssetUnit
    {
        [Display ( Name = "Card" )] 
        Card = 1,

        [Display ( Name = "Cái" )] 
        C = 2,
        [Display ( Name = "Mét" )] 
        M = 3,

        [Display ( Name = "Bộ" )]
        B = 4,

        [Display ( Name = "Khối" )] 
        K = 5
    }
}