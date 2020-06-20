using Innoivce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innoivce.ViewModels
{
    public class ProductStoreUnitViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<Unit> Units { get; set; }
    }
}