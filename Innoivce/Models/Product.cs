using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innoivce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal price { get; set; }
        public decimal Discount { get; set; }
        public int QunatityInStore { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public IEnumerable<Innvoice> Innvoices { get; set; }

    }
}