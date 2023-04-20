using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
    [Table("TBL_Warehouses")]
    public class Warehouse
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        [Required]
        public string Center { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
    }
}