using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class StoreroomItem
    {
        public int Id { get; set; }

        public int ItemId { get; set; }   // 🔗 Item

        public string? Storename { get; set; } // optional

        public string? IssueCost { get; set; }
        public decimal? UnitCost { get; set; }

        public string? DefaultBin { get; set; }
        public decimal? CurrentBalance { get; set; }

        public string? Lot { get; set; }

        public string? IssueUnit { get; set; }
        public string? OrderUnit { get; set; }

        public string? Site { get; set; }

        public bool IsActive { get; set; } = false;

        public string IsDelete { get; set; } = "A";

        public int? UseId { get; set; }

        public Item? Item { get; set; }


    }
}
