using qlts.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
    [Table("TBL_Warehouses")]
    public class Warehouse:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public CenterUnit Center { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public string Note { get; set; }
    }
}