using Innoivce.Models;
using Innoivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innoivce.Controllers
{
    public class InvoiceController : Controller
    {
        ApplicationDbContext _context;
        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Invoice
        [Route("Inovice/Index")]
        public ActionResult Index()
        {
            var innvoices = _context.Innvoices.ToList();
            var model = new InvoiceViewModel
            {
                Innvoice= new Innvoice(),
                Innvoices = innvoices
            };
            return View(model);
        }

     
        [HttpPost]
        [Route("Invoice/New")]
        public ActionResult New(Innvoice innvoice)
        {

            _context.Innvoices.Add(innvoice);
          
           
            _context.SaveChanges();

          
            return RedirectToAction("AddProductToInnvoice/" +innvoice.Id, "Invoice");
        }
        [Route("Invoice/AddProductToInnvoice/{id}")]
        public ActionResult AddProductToInnvoice(int id)
        {
            var invoice = _context.Innvoices.SingleOrDefault(c => c.Id == id);
            var productinvoice = new ProductInnovieViewModel
            {
                Products = _context.Products.Include(p=>p.Unit).ToList(),
                productInnvoices = _context.ProductInnvoices.Where(p=>p.InnvoiceId==invoice.Id).ToList(),
                Innvoices=invoice,
                ProductInnvoice=new ProductInnvoice()
            };
            return View(productinvoice);
        }

        [HttpPost]
        [Route("Invoice/SaveProductToInnvoice/{id}")]
        public ActionResult SaveProductToInnvoice(int id, int ProductId,ProductInnvoice model )
        {
            var product = _context.Products.SingleOrDefault(c => c.Id ==  ProductId);
             var innvoice = _context.Innvoices.SingleOrDefault(c => c.Id==id);
            var productInnvice = new ProductInnvoice();
            productInnvice.InnvoiceId =innvoice.Id;
            productInnvice.ProductId = product.Id;
          
            productInnvice.Quantity = model.Quantity;
            productInnvice.Tax = model.Tax;
            productInnvice.Total = product.price * productInnvice.Quantity;
            productInnvice.Net =productInnvice.Total- model.Tax;
            _context.ProductInnvoices.Add(productInnvice);
            _context.SaveChanges();
            return RedirectToAction("AddProductToInnvoice/"+id, "Invoice");
        }


       
    }
}