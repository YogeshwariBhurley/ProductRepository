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
            return View(db.ProductCategories_Context.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductCategories objProductCategories)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories_Context.Add(objProductCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objProductCategories);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategories productCategories = db.ProductCategories_Context.Find(id);
            if (productCategories == null)
            {
                return HttpNotFound();
            }
            return View(productCategories);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] ProductCategories productCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategories);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategories productCategories = db.ProductCategories_Context.Find(id);
            if (productCategories == null)
            {
                return HttpNotFound();
            }
            return View(productCategories);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCategories productCategories = db.ProductCategories_Context.Find(id);
            if (productCategories == null)
            {
                return HttpNotFound();
            }
            return View(productCategories);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategories productCategories = db.ProductCategories_Context.Find(id);
            db.ProductCategories_Context.Remove(productCategories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}