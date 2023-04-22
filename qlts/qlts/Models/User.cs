using qlts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
   
    public class User : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [StringLength(100)]
        [Required]
        public string Password { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        [Required]
        public string UserName { get; set; }


        [StringLength(12)]
        [Required]
        public string Phone { get; set; }

        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public PositionType Position { get; set; }
        
    }
}