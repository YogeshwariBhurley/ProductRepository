using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using ProductDemoApplication.Context;
using ProductDemoApplication.Models;
using System.Net;
using System.Data.Entity;
using ProductDemoApplication.Entities;
using System.Web.Mvc;

namespace ProductDemoApplication.Servieces
{
    public class PurchaseTransactionService
    {
        ProductContext db = new ProductContext();
        public PurchaseTransaction GetCreatedPurchaseTransaction(PurchaseTransaction objPT, FormCollection frm)
        {
            PurchaseTransactionDetail objPD = new PurchaseTransactionDetail();
            PurchaseTransactionDetails objPTD = new PurchaseTransactionDetails();

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
            return objPT;
        }
        public List<Products> GetProduct(int product)
        {
            var categories = db.Product_Context.Where(c => c.ProductCategoryId == product);
            return categories.ToList();
        }
        public List<Products> FillRate(int prodctCat)
        {
            var products = from prod in db.Product_Context where prod.Id == prodctCat select prod;
            return products.ToList();

        }
        public List<PurchaseTransactionReport> GetReport(int custId)
        {
            var Report = (from m in db.PurchaseTransactionSummery_Context
                          join n in db.PurchaseTransactionDetails_Context on new { a = m.customerId, b = m.Id } equals new { a = custId, b = n.PurchaseTransactionSummaryId }
                          join s in db.Product_Context on n.ProductId equals s.Id
                          join c in db.ProductCategories_Context on s.ProductCategoryId equals c.Id

                          select new PurchaseTransactionReport
                          {
                             PurchaseTransactionSummaryId= n.PurchaseTransactionSummaryId,
                             Quantity= n.Quantity,
                             Rate =n.Rate,
                             Name= s.Name,
                             productCategoryName = c.Name
                          }).ToList();
            return Report;
        }
    }
}