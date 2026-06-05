using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ItemCondition
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string ConditionCode { get; set; }
        public string Description { get; set; }

        public decimal ConditionRate { get; set; }

        public int? UseId { get; set; }

    }
}
