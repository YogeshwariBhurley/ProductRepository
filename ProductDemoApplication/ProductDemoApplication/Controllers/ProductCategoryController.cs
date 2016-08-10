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
        // GET: ProductCategory
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            
            var prodLists = from ProductCategories in db.ProductCategories_Context select ProductCategories;
            var Prods = new List<ProductCategories>();
            if (prodLists.Any())
            {
                foreach (var prod in prodLists)
                {
                    ProductCategories prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prod);
                    Prods.Add(prodModel);
                   
                }
            }
            return View(Prods);
            //return View(db.ProductCategories_Context.ToList());
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