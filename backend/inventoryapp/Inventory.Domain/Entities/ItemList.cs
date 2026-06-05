using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ItemList
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public bool Status { get; set; } = true;

        public int? UseId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
