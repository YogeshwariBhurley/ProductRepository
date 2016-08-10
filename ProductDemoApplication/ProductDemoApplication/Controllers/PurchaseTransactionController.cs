using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApplication.Context;
using ProductDemoApplication.Models;

namespace ProductDemoApplication.Controllers
{
    public class PurchaseTransactionController : Controller
    {
        // GET: PurchaseTransaction
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var p = new PurchaseTransactionSummeries();
            p.customer = db.Customer_Context.ToList();
            return View(p);
       
        

        }
    }
}