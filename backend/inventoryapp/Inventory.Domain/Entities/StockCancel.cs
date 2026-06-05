using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class StockCancel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public decimal Qty { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public string ReferenceNo { get; set; } = string.Empty;

        public bool IsCancelled { get; set; } = false;

        public int? CancelledReferenceId { get; set; }

        public int? UseId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
