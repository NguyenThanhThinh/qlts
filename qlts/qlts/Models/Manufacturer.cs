using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlts.Models
{
    [Table("TBL_Manufacturers")]
    public class Manufacturer
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public string Note { get; set; }
    }
}