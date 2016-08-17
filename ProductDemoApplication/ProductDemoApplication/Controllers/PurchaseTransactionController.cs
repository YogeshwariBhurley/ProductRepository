using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApplication.Context;
using ProductDemoApplication.Models;
using System.Data;
using AutoMapper;
using System.Data.Entity;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Controllers
{
    public class PurchaseTransactionController : Controller
    {
        // GET: PurchaseTransaction
        public static DataTable dtGrid = new DataTable();

        ProductContext db = new ProductContext();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            // ViewBag.ProductId = new SelectList(db.Product_Context, "Id", "Name");      
            ViewBag.CustomerName = new SelectList(db.Customer_Context, "Id", "Name");
            //ViewBag.PurchaseTransactionSummaryId = new SelectList(db.Customer_Context, "Id", "Name");
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
            return View();
        }
        public ActionResult FillProduct(int product)
        {
            var categories = db.Product_Context.Where(c => c.ProductCategoryId == product);
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FillText(int prodctCat)
        {
            var products = from prod in db.Product_Context where prod.Id == prodctCat select prod;
            return Json(products, JsonRequestBehavior.AllowGet);
        }
       

        public ActionResult NewCreate()
        {
            ViewBag.CustomerId = new SelectList(db.Customer_Context, "Id", "Name");
           // ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
           ViewBag.ProductCategoryName=new SelectList(db.ProductCategories_Context, "Id", "Name");
            return View();

        }
        [HttpPost]

        public ActionResult NewCreate(FormCollection frm, PurchaseTransaction objProd)
        {
            if (frm["Command"] == "AddProduct")
            {              
                objProd.customerId = Convert.ToInt32(frm["CustomerId"]);
             
                int ProductId = Convert.ToInt32(frm["ProductId"]);              
                int Quantity = Convert.ToInt32(frm["Quantity"]);
                decimal Rate = Convert.ToInt32(frm["Rate"]);
                int CustomerId = Convert.ToInt32(frm["CustomerId"]);
                //var PurchaseTransactionSummaryId = from m in db.PurchaseTransactionSummery_Context where m.customerId == CustomerId select m.Id;
                //ViewBag.PurchaseTransactionSummaryId = PurchaseTransactionSummaryId;

                if (dtGrid.Columns.Count < 1)
                {
                    dtGrid.Columns.Add("CustomerId",typeof(int));
                    dtGrid.Columns.Add("ProductId", typeof(int));
                    dtGrid.Columns.Add("Quantity", typeof(int));
                    dtGrid.Columns.Add("Rate", typeof(decimal));
                }
                dtGrid.Rows.Add(CustomerId,ProductId, Quantity, Rate);
                ViewData["data"] = dtGrid;
               ViewBag.CustomerId = new SelectList(db.Customer_Context, "Id", "Name");
                ViewBag.ProductCategoryName = new SelectList(db.ProductCategories_Context, "Id", "Name");
                //try
                //{
                //    objProd.customerId = Convert.ToInt32(frm["CustomerId"]);
                 
                //    if (ModelState.IsValid)
                //    {

                //        var ProdModelCust = Mapper.Map<PurchaseTransaction, PurchaseTransactionSummeries>(objProd);
                        
                //        db.PurchaseTransactionSummery_Context.Add(ProdModelCust);

                //        db.SaveChanges();
                //        var prodModel = Mapper.Map<PurchaseTransaction, PurchaseTransactionDetails>(objProd);
                //        prodModel.PurchaseTransactionSummaryId = ProdModelCust.Id;
                //        db.PurchaseTransactionDetails_Context.Add(prodModel);
                //        db.SaveChanges();
                //    }
                //    ViewBag.CustomerId = new SelectList(db.Customer_Context, "Id", "Name");
                //    //  ViewBag.PurchaseTransactionSummaryId = new SelectList(db.Customer_Context, "Id", "Name");
                //    ViewBag.ProductCategoryName = new SelectList(db.ProductCategories_Context, "Id", "Name");
                //    return View(objProd);
                //}
                //catch (Exception ex)
                //{
                //    string message = ex.Message;
                //    return View();
                //}



            }
            if (frm["Command"] == "SaveProduct")
            {
                
                try
                {
                    objProd.customerId = Convert.ToInt32(frm["CustomerId"]);

                    if (ModelState.IsValid)
                    {

                        var ProdModelCust = Mapper.Map<PurchaseTransaction, PurchaseTransactionSummeries>(objProd);

                        db.PurchaseTransactionSummery_Context.Add(ProdModelCust);

                        db.SaveChanges();
                        var prodModel = Mapper.Map<PurchaseTransaction, PurchaseTransactionDetails>(objProd);
                        prodModel.PurchaseTransactionSummaryId = ProdModelCust.Id;
                        db.PurchaseTransactionDetails_Context.Add(prodModel);
                        db.SaveChanges();
                    }
                    ViewBag.CustomerId = new SelectList(db.Customer_Context, "Id", "Name");
                   
                    ViewBag.ProductCategoryName = new SelectList(db.ProductCategories_Context, "Id", "Name");
                    return View(objProd);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    return View();
                }

            }
            return View();
        }


       
        [HttpPost, ActionName("Create")]
        public ActionResult Create(FormCollection frm, PurchaseTransactionDetailsCreateEditDelete objProd)

        {
          

            if (frm["Command"] == "AddProduct")
            {
                PurchaseTransactionDetailsCreateEditDelete objPT = new PurchaseTransactionDetailsCreateEditDelete();
                PurchaseTransactionSummeriesCreateEdit objPS = new PurchaseTransactionSummeriesCreateEdit();

                int ProductId = Convert.ToInt32(frm["ProductId"]);
               // string ProductName = (frm["ProductName)"]).ToString();
                int Quantity = Convert.ToInt32(frm["Quantity"]);
                decimal Rate = Convert.ToInt32(frm["Rate"]);
                if (dtGrid.Columns.Count < 1)
                {
                    dtGrid.Columns.Add("ProductId", typeof(int));
                    dtGrid.Columns.Add("Quantity", typeof(int));
                    dtGrid.Columns.Add("Rate", typeof(decimal));
                }
                dtGrid.Rows.Add(ProductId, Quantity, Rate);
                ViewData["data"] = dtGrid;
                
                try
                {
                    if (ModelState.IsValid)
                    {
                        var prodModel = Mapper.Map<PurchaseTransactionDetailsCreateEditDelete, PurchaseTransactionDetails>(objProd);
                        db.PurchaseTransactionDetails_Context.Add(prodModel);
                         var ProdModelCust = Mapper.Map<PurchaseTransactionSummeriesCreateEdit, PurchaseTransactionSummeries>(objPS);
                       // var ProdModelCust = Mapper.Map<PurchaseTransactionDetailsCreateEditDelete,PurchaseTransactionSummeriesCreateEdit>(objPS);
                        db.PurchaseTransactionSummery_Context.Add(ProdModelCust);

                        db.SaveChanges();
                    }
                    ViewBag.CustomerName = new SelectList(db.Customer_Context, "Id", "Name");
                    //  ViewBag.PurchaseTransactionSummaryId = new SelectList(db.Customer_Context, "Id", "Name");
                    ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
                    return View(objProd);                
                }
                catch
                {
                    return View();
                }              
            }
            return View();

         
        }
    }
}