using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class CurrencyDetails
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public decimal ExchangeRate { get; set; }
        public int DecimalPlaces { get; set; }
        public bool IsDefault { get; set; }
        public string Status { get; set; }
    }
}
