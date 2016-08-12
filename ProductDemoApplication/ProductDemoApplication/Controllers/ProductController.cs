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
       
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            try
            {
                var product = from Products in db.Product_Context select Products;
                var prods = new List<ProductCreateEditModel>();
                if (product.Any())
                {
                    foreach (var prod in product)
                    {
                        ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(prod);
                        prods.Add(prodModel);
                    }
                }
                return View(prods);
            }
            catch
            {
                return ViewBag();
            }
            
        }
        public ActionResult Create()
        {
            try
            {
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
                return View();
            }
            catch
            {
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult Create(ProductCreateEditModel objProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var prodModel = Mapper.Map<ProductCreateEditModel, Products>(objProduct);
                    db.Product_Context.Add(prodModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name",objProduct.ProductCategoryId);
                return View(objProduct);
            }             
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int ?id)
        {
            try
            {
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
                var prodDetails = db.Product_Context.Find(id);
                if (prodDetails == null)
                {
                    return HttpNotFound();
                }
                var prodModel = Mapper.Map<Products, ProductCreateEditModel>(prodDetails);
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name",prodDetails.ProductCategoryId);
                return View(prodModel);
            }
            catch
            {
                return View();
            }      
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] ProductCreateEditModel objProduct)
        {
            try
            {
                var prodModel = Mapper.Map<ProductCreateEditModel, Products>(objProduct);
                db.Entry(prodModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult Details(int? id)
        {
            try
            {
                var ProductDetails = db.Product_Context.Find(id);
                ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(ProductDetails);
                return View(prodModel);
            }
            catch
            {
                return View();
            }
           
        }
        public ActionResult Delete(int? id)
        {
            try
            {
                var ProductDetails = db.Product_Context.Find(id);
                var prod = Mapper.Map<Products, ProductCreateEditModel>(ProductDetails);
                return View(prod);
            }
            catch
            {
                return View();
            }
          
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var ProductDetails = db.Product_Context.Find(id);
                db.Product_Context.Remove(ProductDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } 
           
        }

    }
}
    
