using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class AlternatesItem
    {
        public int Id { get; set; }

        // 🔗 Foreign Key (Main Item)
        public int ItemId { get; set; }

        // 🔁 Alternate Item Reference
        public string al_item { get; set; }

        // Optional fields (for UI display)

        public string al_description { get; set; }

        public string al_commodityGroup { get; set; }
        public string al_commodityCode { get; set; }

        public bool al_rotating { get; set; }

        public int? UseId { get; set; }


    }
}
