using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class UserSession
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        public string IpAddress { get; set; }

        public string Device { get; set; }

        public bool IsActive { get; set; }
    }
}
