using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        public string DiscountName { get; set; } = "";

        public string DiscountType { get; set; } = "";

        public decimal DiscountValue { get; set; }

        public decimal MinimumOrderAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; } = "";
    }
}
