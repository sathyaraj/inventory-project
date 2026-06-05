using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }

        public string TaxName { get; set; } = "";

        public string TaxCode { get; set; } = "";

        public string TaxType { get; set; } = "";

        public decimal TaxPercentage { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string Status { get; set; } = "";
    }
}
