using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApp.Context;
using ProductDemoApp.Models;
using System.Net;
using System.Data.Entity;


namespace ProductDemoApp.Controllers
{
    public class ProductCategorywiseController : Controller
    {
        // GET: ProductCategorywise
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {  
            return View(db.Product_Context.ToList());
        }
        public ActionResult Create()
        {        
            var p = new Products();        
            p.ProductCategories = db.ProductCategories_Context.ToList();
            return View(p); 
        }
        [HttpPost]
        public ActionResult Create(Products objProducts)
        {
            if (ModelState.IsValid)
            {

                db.Product_Context.Add(objProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            objProducts.ProductCategories = db.ProductCategories_Context.ToList();
            return View(objProducts);



        }
    }
}