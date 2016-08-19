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
using System.Text;

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

            ViewBag.CustomerName = new SelectList(db.Customer_Context, "Id", "Name");
            ViewBag.ProductCategoryName = new SelectList(db.ProductCategories_Context, "Id", "Name");
            var model = new PurchaseTransaction();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PurchaseTransaction objPT, FormCollection frm)

        {
            PurchaseTransactionDetail objPD = new PurchaseTransactionDetail();
            PurchaseTransactionDetails objPTD = new PurchaseTransactionDetails();

            try
            {

                foreach (var product in objPT.PurchaseTransactionDetails)
                {
                    objPT.customerId = Convert.ToInt32(frm["CustomerName"]);
                    objPTD.ProductId = Convert.ToInt32(frm["ProductId"]);

                    var ProdModelCust = Mapper.Map<PurchaseTransaction, PurchaseTransactionSummeries>(objPT);
                    ProdModelCust.customerId = objPT.customerId;
                    db.PurchaseTransactionSummery_Context.Add(ProdModelCust);
                    db.SaveChanges();

                    var prodModel = Mapper.Map<PurchaseTransaction, PurchaseTransactionDetails>(objPT);
                    prodModel.PurchaseTransactionSummaryId = ProdModelCust.Id;
                    prodModel.Quantity = product.Quantity;
                    prodModel.Rate = product.Rate;
                    prodModel.ProductId = product.ProductId;

                    db.PurchaseTransactionDetails_Context.Add(prodModel);
                    db.SaveChanges();
                }


                ViewBag.CustomerName = new SelectList(db.Customer_Context, "Id", "Name");

                ViewBag.ProductCategoryName = new SelectList(db.ProductCategories_Context, "Id", "Name");
                return View(objPT);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View();
            }
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

        public ActionResult FillReport(int custId)
        {


            //  var Report = from m in db.PurchaseTransactionSummery_Context where m.customerId == custId select m;
            var Report = (from m in db.PurchaseTransactionSummery_Context
                          join n in db.PurchaseTransactionDetails_Context on new { a = m.customerId, b = m.Id } equals new { a = custId, b = n.PurchaseTransactionSummaryId }
                          join s in db.Product_Context on n.ProductId equals s.Id
                          join c in db.ProductCategories_Context on s.ProductCategoryId equals c.Id
                          
                          select new
                          {
                              n.PurchaseTransactionSummaryId,
                              n.Quantity,
                              n.Rate,
                              s.Name,
                              productCategoryName=c.Name
                          }).ToList();




            return Json(Report, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ReportScreen()
        {
            ViewBag.CustomerName = new SelectList(db.Customer_Context, "Id", "Name");
            return View();
        }




        public ActionResult NewCreate()
        {
            ViewBag.CustomerId = new SelectList(db.Customer_Context, "Id", "Name");
            // ViewBag.ProductCategoryId = new SelectList(db.ProductCategories_Context, "Id", "Name");
            ViewBag.ProductCategoryName = new SelectList(db.ProductCategories_Context, "Id", "Name");
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
                    dtGrid.Columns.Add("CustomerId", typeof(int));
                    dtGrid.Columns.Add("ProductId", typeof(int));
                    dtGrid.Columns.Add("Quantity", typeof(int));
                    dtGrid.Columns.Add("Rate", typeof(decimal));
                }
                dtGrid.Rows.Add(CustomerId, ProductId, Quantity, Rate);
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


    }
}