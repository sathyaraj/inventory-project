using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ItemSpecification
    {
        public int Id { get; set; }

        public int Itemid { get; set; }

        public string SpcCode { get; set; }

        public string SpcItem { get; set; }

        public string? Classification { get; set; }

        public string? ClassDescription { get; set; }

        public int? UseId { get; set; }

        public List<ItemSpecificationDetails>? Details { get; set; } = new();

    }
}
