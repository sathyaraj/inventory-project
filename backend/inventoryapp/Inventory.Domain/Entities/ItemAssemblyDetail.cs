using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ItemAssemblyDetail
    {
        public int Id { get; set; }

        public int AssemblyId { get; set; }

        public string? Item { get; set; }
        public string? Description { get; set; }
        public decimal? Quantity { get; set; }
        public string? Remark { get; set; }

        public int? UseId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ItemAssembly? Assembly { get; set; }
    }
}
