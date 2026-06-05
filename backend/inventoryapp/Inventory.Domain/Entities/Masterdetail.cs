using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Masterdetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int GroupId { get; set; }
        public string MasterName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
