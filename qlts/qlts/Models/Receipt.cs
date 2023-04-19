using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qlts.Models
{
    public class Receipt : BaseEntity
    {
        [StringLength(50)]
        [Required]
        [Index(IsUnique = true)]
        public string Code { get; set; }
        /// <summary>
        /// Ngày bắt đầu sử dụng
        /// </summary>
        [Required]
        public DateTime? ReceiptDate { get; set; }
        /// <summary>
        /// Ngày ghi tăng
        /// </summary>
        [Required]
        public DateTime? IncreaseDate { get; set; }
        /// <summary>
        /// Tổng nguồn kinh phí
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}