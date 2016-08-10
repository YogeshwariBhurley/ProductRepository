﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApp.Context;
using ProductDemoApp.Models;

namespace ProductDemoApp.Controllers
{
    public class TransactionDetailController : Controller
    {
        // GET: TransactionDetail
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var p = new PurchaseTransactionDetails();
            p.Products = db.Product_Context.ToList();
            ViewBag.Name = new SelectList(db.Customer_Context, "Id", "Name");
            ViewBag.ProductCategory = new SelectList(db.ProductCategories_Context, "Id", "Name");

            return View(p);

        }
    }
}