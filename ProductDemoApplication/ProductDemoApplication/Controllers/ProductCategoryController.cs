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
using ProductDemoApplication.Servieces;


using AutoMapper;

namespace ProductDemoApplication.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductContext db = new ProductContext();
        public ActionResult Index(ProductCategoryService objPCS)
        {
            try
            {
                 var Prods=objPCS.GetCategory();        

                //ProductCategoryCreateEditModel objproduct = new ProductCategoryCreateEditModel();
                //var prodLists = from ProductCategories in db.ProductCategories_Context select ProductCategories;
                //var Prods = new List<ProductCategoryCreateEditModel>();
                //if (prodLists.Any())
                //{
                //    foreach (var prod in prodLists)
                //    {

                //        ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prod);
                //        Prods.Add(prodModel);
                //    }
                //}
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
        public ActionResult Create(ProductCategoryCreateEditModel objProductCategory, ProductCategoryService objPCS)
        {
            try

            {
                objPCS.GetCreatedCategory(objProductCategory);             
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }         
        }
        public ActionResult Edit(int? id, ProductCategoryService objPCS)
        {
         try
            {
                var prodModel= objPCS.ShowEditedCategory(id);             
                return View(prodModel);
            }
            catch
            {
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")]ProductCategoryService objPCS, ProductCategoryCreateEditModel objProductCategory)
        {
            try
            {
                objPCS.GetEditedCategory(objProductCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int? id, ProductCategoryService objPCS)
        {
            try
            {               
                var prodModel = objPCS.GetDetailsCategory(id);
                return View(prodModel);
            }
            catch
            {
                return View();
            }
           
        }
        public ActionResult Delete(int? id, ProductCategoryService objPCS)
        {
            try
            {
                var prod = objPCS.ShowDeletedCategory(id);
                return View(prod);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, ProductCategoryService objPCS)
        {
          try
            {
                ProductCategoryCreateEditModel objProductCat = new ProductCategoryCreateEditModel();
                objPCS.GetDeletedCategory(id, objProductCat);
            //    ProductCategoryCreateEditModel objProductCategory = new ProductCategoryCreateEditModel();
            //    objPCS.GetDeletedCategory(id, objProductCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}