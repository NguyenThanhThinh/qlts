using System;

namespace qlts.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}