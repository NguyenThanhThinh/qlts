using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
    public class Department : BaseEntity
    {
        [StringLength ( 20 )]
        [Required]
        [Index ( IsUnique = true )]

        public string Code { get; set; }

        [StringLength ( 200 )]
        [Required]
        public string Name { get; set; }

        [StringLength ( 200 )]
        public string Description { get; set; }
    }
}