using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApplication.Context;
using ProductDemoApplication.Models;
using System.Net;
using System.Data.Entity;
using ProductDemoApplication.Entities;


using AutoMapper;

namespace ProductDemoApplication.Controllers
{
    public class ProductCategoryController : Controller
    {
        
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            try
            {
                var prodLists = from ProductCategories in db.ProductCategories_Context select ProductCategories;
                var Prods = new List<ProductCategoryCreateEditModel>();
                if (prodLists.Any())
                {
                    foreach (var prod in prodLists)
                    {

                        ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prod);
                        Prods.Add(prodModel);

                    }
                }
                return View(Prods);
            }
            catch
            {
                return View();
            }
            

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]


        public ActionResult Create(ProductCategoryCreateEditModel objProductCategory)
        {
            try
            {
                var prodModel = Mapper.Map<ProductCategoryCreateEditModel, ProductCategories>(objProductCategory);
                db.ProductCategories_Context.Add(prodModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }         
        }
        public ActionResult Edit(int? id)
        {
         try
            {
                var prodDetails = db.ProductCategories_Context.Find(id);
                var prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prodDetails);
                return View(prodModel);
            }
            catch
            {
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] ProductCategoryCreateEditModel objProductCategory)
        {
            try
            {
                var prodModel = Mapper.Map<ProductCategoryCreateEditModel, ProductCategories>(objProductCategory);
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
                var ProductCatDetails = db.ProductCategories_Context.Find(id);
                ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(ProductCatDetails);
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
                var ProductCatDetails = db.ProductCategories_Context.Find(id);
                var prod = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(ProductCatDetails);
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
                var ProductCatDetails = db.ProductCategories_Context.Find(id);
                db.ProductCategories_Context.Remove(ProductCatDetails);
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