using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyPhone { get; set; }

        public string BusinessType { get; set; }

        public string CompanyLogo { get; set; }

        public string CompanyDescription { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string SubscriptionPlan { get; set; }

        public int UserLimit { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
