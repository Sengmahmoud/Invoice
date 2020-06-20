using Innoivce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innoivce.ViewModels
{
    public class InvoiceViewModel
    {
        public Innvoice Innvoice { get; set; }
        public IEnumerable<Innvoice> Innvoices { get; set; }
    }
}