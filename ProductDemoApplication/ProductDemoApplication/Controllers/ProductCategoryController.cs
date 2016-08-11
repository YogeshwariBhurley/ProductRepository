﻿using System;
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

            // var prodLists = from ProductCategories in db.ProductCategories_Context select ProductCategories;
            var prodLists = from ProductCategories in db.ProductCategories_Context select ProductCategories;
            var Prods = new List<ProductCategoryCreateEditModel>();
            if (prodLists.Any())
            {
                foreach (var prod in prodLists)
                {
                    //  ProductCategories prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prod);
                    ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prod);
                    Prods.Add(prodModel);

                }
            }
            return View(Prods);

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
            
            var prodDetails = db.ProductCategories_Context.Find(id);
            var prodModel = Mapper.Map<ProductCategories,ProductCategoryCreateEditModel>(prodDetails);
            return View(prodModel);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] ProductCategoryCreateEditModel objProductCategory)
        {

            //var prodModel = Mapper.Map<ProductCategoryCreateEditModel, ProductCategories>(objProductCategory);
            db.Entry(objProductCategory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Details(int? id)
        {

            var ProductCatDetails = db.ProductCategories_Context.Find(id);
            ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(ProductCatDetails);
            return View(prodModel);
        }
        public ActionResult Delete(int? id)
        {

            var ProductCatDetails = db.ProductCategoryCreateEditModels.Find(id);
            var prod = Mapper.Map<ProductCategoryCreateEditModel, ProductCategories>(ProductCatDetails);
            return View(prod);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            var ProductCatDetails = db.ProductCategoryCreateEditModels.Find(id);
         
            db.ProductCategoryCreateEditModels.Remove(ProductCatDetails);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}