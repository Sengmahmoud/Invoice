using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innoivce.Models
{
    public class Innvoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}