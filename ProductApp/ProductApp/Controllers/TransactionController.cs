using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductApp.Models;
using ProductApp.Context;

namespace ProductApp.Controllers
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
            return View();
        }
    }
}