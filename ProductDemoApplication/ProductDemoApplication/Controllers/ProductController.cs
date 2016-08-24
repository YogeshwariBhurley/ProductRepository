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
using ProductDemoApplication.Servieces;

namespace ProductDemoApplication.Controllers
{
    public class ProductController : Controller
    {
       
        ProductContext db = new ProductContext();
        public ActionResult Index(ProductService objPS)
        {
            try
            {
                var prods = objPS.GetProduct();
                //var product = from Products in db.Product_Context select Products;
                //var prods = new List<ProductCreateEditModel>();
                //if (product.Any())
                //{
                //    foreach (var prod in product)
                //    {
                //        ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(prod);
                //        prods.Add(prodModel);
                //    }
                //}
                return View(prods);
            }
            catch(Exception ex)
            {
                var str = ex.Message;
                return View();
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
        public ActionResult Create(ProductCreateEditModel objProduct,ProductService objPS)
        {
            try
            {
              
                if (ModelState.IsValid)
                    {
                    //    var prodModel = Mapper.Map<ProductCreateEditModel, Products>(objProduct);
                    //    db.Product_Context.Add(prodModel);
                    //    db.SaveChanges();
                    //    return RedirectToAction("Index");
                 objPS.GetCreatedProduct(objProduct);
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
        public ActionResult Edit(int ?id,ProductService objPS)
        {
            try
            {
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
                var prodModel = objPS.ShowEditedProduct(id);
                //var prodDetails = db.Product_Context.Find(id);
                //if (prodDetails == null)
                //{
                //    return HttpNotFound();
                //}
                //var prodModel = Mapper.Map<Products, ProductCreateEditModel>(prodDetails);
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name",prodModel.ProductCategoryId);
                return View(prodModel);
            }
            catch
            {
                return View();
            }      
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] ProductCreateEditModel objProduct,ProductService objPS)
        {
            try
            {
                //var prodModel = Mapper.Map<ProductCreateEditModel, Products>(objProduct);
                //db.Entry(prodModel).State = EntityState.Modified;
                //db.SaveChanges();
                objPS.GetEditedProduct(objProduct);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult Details(int? id,ProductService objPS)
        {
            try
            {
                var prodModel = objPS.GetDetailedProduct(id);
                //var ProductDetails = db.Product_Context.Find(id);
                //ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(ProductDetails);
                return View(prodModel);
            }
            catch
            {
                return View();
            }
           
        }
        public ActionResult Delete(int? id,ProductService objPS)
        {
            try
            {
               var prod= objPS.ShowDeletedProduct(id);
                //var ProductDetails = db.Product_Context.Find(id);
                //var prod = Mapper.Map<Products, ProductCreateEditModel>(ProductDetails);
                return View(prod);
            }
            catch
            {
                return View();
            }
          
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id,ProductService objPS)
        {
            try
            {
                ProductCreateEditModel objProuct = new ProductCreateEditModel();
                objPS.GetDeletedProduct(id, objProuct);
                //var ProductDetails = db.Product_Context.Find(id);
                //db.Product_Context.Remove(ProductDetails);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } 
           
        }

    }
}
    
