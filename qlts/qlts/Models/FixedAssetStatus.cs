using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qlts.Models
{
    [Table("TBL_FixedAssetStatus")]
    public class FixedAssetStatus : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public string Note { get; set; }
    }
}