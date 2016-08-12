using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApplication.Context;
using ProductDemoApplication.Models;

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
            List < PurchaseTransactionDetailsCreateEditDelete >objPurchaseList= new List<PurchaseTransactionDetailsCreateEditDelete>();
            objPurchaseList.Add(new PurchaseTransactionDetailsCreateEditDelete() { ProductId= objPurchase.Id, Rate= objPurchase.Rate, Quantity = objPurchase.Quantity});
            //objPurchaseList.Add(objPurchase.Rate);
            //objPurchaseList.Add(objPurchase.Quantity);
           
            return Json(objPurchaseList, JsonRequestBehavior.AllowGet);
              
        }
    }
}