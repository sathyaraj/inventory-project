using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Stocklist
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal qty {  get; set; }

        public string ItemSet { get; set; }

        public decimal itemcancel { get; set; }

        public int storeroomid { get; set; }

        public decimal storeroom { get; set; }


        public bool status { get; set; }

        public int? UseId { get; set; }

        public DateTime createdtime { get; set; }

    }
}
