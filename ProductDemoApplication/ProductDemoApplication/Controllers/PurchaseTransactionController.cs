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
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {

            // ViewBag.ProductId = new SelectList(db.Product_Context, "Id", "Name");
            ViewBag.PurchaseTransactionSummaryId = new SelectList(db.Customer_Context, "Id", "Name");
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
        public JsonResult GetProductData()
        {
            PurchaseTransactionDetailsCreateEditDelete objPurchase = new PurchaseTransactionDetailsCreateEditDelete();
            List<PurchaseTransactionDetailsCreateEditDelete> objPurchaseList = new List<PurchaseTransactionDetailsCreateEditDelete>();
            objPurchaseList.Add(new PurchaseTransactionDetailsCreateEditDelete() { ProductId = objPurchase.Id, Rate = objPurchase.Rate, Quantity = objPurchase.Quantity });
            //objPurchaseList.Add(objPurchase.Rate);
            //objPurchaseList.Add(objPurchase.Quantity);

            return Json(objPurchaseList, JsonRequestBehavior.AllowGet);

        }
        public static DataTable dtGrid = new DataTable();
        [HttpPost, ActionName("Create")]
        public ActionResult Create(FormCollection frm, PurchaseTransactionDetailsCreateEditDelete objProd)

        {
            // = new PurchaseTransactionDetailsCreateEditDelete();

            if (frm["Command"] == "AddProduct")
            {
                PurchaseTransactionDetailsCreateEditDelete objPT = new PurchaseTransactionDetailsCreateEditDelete();
                PurchaseTransactionSummeriesCreateEdit objPS = new PurchaseTransactionSummeriesCreateEdit();

                int ProductId = Convert.ToInt32(frm["ProductId"]);
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
                ViewBag.PurchaseTransactionSummaryId = new SelectList(db.Customer_Context, "Id", "Name");
                ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
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
                    return View(objProd);
                }
                catch
                {
                    return View();
                }

              

            }
            
            




            return View();

            //if (frm["Command"] == "Update")
            //{
            //    PurchaseTransactionDetailsCreateEditDelete objPT = new PurchaseTransactionDetailsCreateEditDelete();
            //    objPT.ProductId = Convert.ToInt32(frm["ProductId"]);
            //    //ViewBag.ProductId = new SelectList(db.Product_Context, "Id", "Name");
            //    ViewBag.PurchaseTransactionSummaryId = new SelectList(db.Customer_Context, "Id", "Name");
            //    ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");


            //    int EditProductId = Convert.ToInt32(frm["txtEditProductId"]);

            //    int EditQuantity = Convert.ToInt32(frm["txtEditQuantity"]);

            //    decimal EditPrice = Convert.ToDecimal(frm["txtEditRate"]);

            //    for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            //    {
            //        DataRow dr = dtGrid.Rows[i];
            //        if (Convert.ToInt32(dr["ProductId"]) == EditProductId)
            //        {

            //            dr["Quantity"] = EditQuantity;
            //            dr["Rate"] = EditPrice;

            //        }
            //    }

            //    ViewData["data"] = dtGrid;

            //    //return value as object
            //    return View(objPT);
            //}

            //if (frm["Command"] == "Delete")
            //{
            //    PurchaseTransactionDetailsCreateEditDelete objPT = new PurchaseTransactionDetailsCreateEditDelete();


            //    int deleteId = Convert.ToInt32(frm["txtDeleteValue"]);
            //    Response.Write(deleteId);


            //    for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            //    {
            //        DataRow dr = dtGrid.Rows[i];
            //        if (Convert.ToInt32(dr["ProductId"]) == deleteId)
            //            dr.Delete();
            //    }

            //    ViewData["data"] = dtGrid;


            //    return View(objPT);
            //}


        }
    }
}