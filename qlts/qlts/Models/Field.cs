using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
  
    public class Field : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }


        public string Note { get; set; }
    }
}