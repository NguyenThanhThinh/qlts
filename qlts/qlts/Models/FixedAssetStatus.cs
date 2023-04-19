using System;

namespace qlts.Models
{
    public class FixedAssetStatus : BaseEntity
    {
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public string Note { get; set; }
    }
}