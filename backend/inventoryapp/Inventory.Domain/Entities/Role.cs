using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Role_Name { get; set; }

        public string Description { get; set; }

        public bool Is_Active { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
            = new List<RolePermission>();
    }
}
