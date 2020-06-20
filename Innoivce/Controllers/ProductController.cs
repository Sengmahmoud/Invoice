using Innoivce.Models;
using Innoivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Innoivce.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();    
        }

        // GET: Product
        [Route("Product/Index")]
        public ActionResult Index()
        {
            var products = _context.Products.Include(p=>p.Store).Include(p=>p.Unit).ToList();
            return View(products);
        }
     //   [HttpGet]
        [Route("Product/New")]
        public ActionResult New()
        {
            var stores = _context.Stores.ToList();
            var units = _context.Units.ToList();
            var viewmodel = new ProductStoreUnitViewModel
            {
                Product = new Product(),
                Stores = stores,
                Units = units

            };

            return View(viewmodel);
        }
        [HttpPost]
      public ActionResult Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");

        }
    }
}