using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace qlts.Models
{
    public class FixedAssetCategory : BaseEntity
    {
        [StringLength ( 50 )]
        [Required]
        [Index ( IsUnique = true )]
        public string Code { get; set; }

        [StringLength ( 100 )]
        [Required] 
        public string Name { get; set; }

        public int? LifeTime { get; set; }

        [StringLength ( 500 )] 
        public string Description { get; set; }
    }
}