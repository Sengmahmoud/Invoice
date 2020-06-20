using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innoivce.Models
{
    public class ProductInnvoice
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InnvoiceId { get; set; }
        public Innvoice Innvoice { get; set; }
        public int Quantity { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal Net { get; set; }
    }
}