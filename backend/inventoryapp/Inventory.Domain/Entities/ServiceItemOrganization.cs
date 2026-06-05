using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class ServiceItemOrganization
    {
        public int Id { get; set; }

        public int ServiceItemId { get; set; }
        public string Organization { get; set; }
        public string GLAccount { get; set; }
        public string TaxCode { get; set; }
        public bool TaxExempt { get; set; }
        public decimal? ReceiptTolerance { get; set; }

        public int? UseId { get; set; }
    }
}
