using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ItemSpecificationDetails
    {
       public int Id { get; set; }

        // ✅ FOREIGN KEY
        public int ItemSpecificationId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ItemSpecification? ItemSpecification { get; set; }

        // Your fields
        public string? Attribute { get; set; }
        public string? Description { get; set; }
        public string? value { get; set; }
        public string? Uom { get; set; }

        public int? UseId { get; set; }
    }
}
