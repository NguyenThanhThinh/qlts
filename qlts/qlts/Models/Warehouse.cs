using qlts.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
  
    public class Warehouse:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [Required]
        public CenterUnit Center { get; set; }


        public WarehouseUnit Unit { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public string Note { get; set; }

        public WarehouseType WarehouseType { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}