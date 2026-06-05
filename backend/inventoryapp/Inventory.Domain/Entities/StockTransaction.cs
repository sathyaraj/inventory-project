using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class StockTransaction
    {
        [Key]
        public int StockTnsId { get; set; }

        public int ItemId { get; set; }

        public decimal QtyIn { get; set; }

        public decimal QtyOut { get; set; }

        public decimal UnitCost { get; set; }

        public decimal BalanceQty { get; set; }

        public decimal BalanceCost { get; set; }

        public string TransactionType { get; set; } // IN / OUT

        public int? UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
