using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ItemAssembly
    {
        public int Id { get; set; }

        public int Itemid { get; set; }
        public string? TopLevelItem { get; set; }
        public string? TopLevelCode { get; set; }

        public string? CurrentLevel { get; set; }
        public string? CurrentLevelCode { get; set; }

        public string? BelongsTo { get; set; }
        public string? Remarks { get; set; }

        public int? UseId { get; set; }

        public List<ItemAssemblyDetail> Details { get; set; } = new();

    }
}
