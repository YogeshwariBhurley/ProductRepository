using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductApp.Context;
using ProductApp.Models;
using System.Net;
using System.Data.Entity;

namespace ProductApp.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            //List<Products> MyProducts = db.Product_Context.ToList();
            //return View(MyProducts);     
                
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