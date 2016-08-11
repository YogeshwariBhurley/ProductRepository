using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApplication.Context;
using ProductDemoApplication.Models;
using System.Net;
using System.Data.Entity;

using AutoMapper;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
        

            var product = from Products in db.Product_Context select Products;
            var prods = new List<ProductCreateEditModel>();
            if (product.Any())
            {
                foreach (var prod in product)
                {
                    // ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(prod);
                    ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(prod);
                    prods.Add(prodModel);
                }
            }
            return View(prods);
        }
        public ActionResult Create()
        {
            var p = new Products();
            //p.ProductCategories = db.ProductCategories_Context.ToList();
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
            //objProducts.ProductCategories = db.ProductCategories_Context.ToList();
            return View(objProducts);         
        }
        public ActionResult Edit(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Product_Context.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name", products.ProductCategoryId);
            return View(products);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name", products.ProductCategoryId);

            return View(products);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Product_Context.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Product_Context.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Product_Context.Find(id);
            db.Product_Context.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
    
