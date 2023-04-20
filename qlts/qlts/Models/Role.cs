using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
    [Table("TBL_Roles")]
    public class Role :BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}