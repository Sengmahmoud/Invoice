using Innoivce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innoivce.ViewModels
{
    public class ProductInnovieViewModel
    {
        public ProductInnvoice ProductInnvoice { get; set; }
        public IEnumerable<ProductInnvoice> productInnvoices { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Innvoice Innvoices { get; set; }
    }
}