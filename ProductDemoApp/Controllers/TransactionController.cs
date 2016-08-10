using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApp.Models;
using ProductDemoApp.Context;

namespace ProductDemoApp.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            return View(db.PurchaseTransactionSummery_Context.ToList());
        }

        public ActionResult Create()
        {
            var p = new PurchaseTransactionSummeries();
            p.customer = db.Customer_Context.ToList();

            return View(p);

        }
        [HttpPost]
        public ActionResult Create(PurchaseTransactionSummeries objTSum)
        {
            if (ModelState.IsValid)
            {

                db.PurchaseTransactionSummery_Context.Add(objTSum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            objTSum.customer = db.Customer_Context.ToList();

            return View(objTSum);
        }
    }
}