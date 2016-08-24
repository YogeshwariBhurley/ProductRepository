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
    //public class PurchaseTransactionService
    //{
    //    ProductContext db = new ProductContext();
    //   public PurchaseTransaction GetCreatedPurchaseTransaction(PurchaseTransaction objPT, FormCollection frm)
    //    {
    //        //PurchaseTransactionDetail objPD = new PurchaseTransactionDetail();
    //        //PurchaseTransactionDetails objPTD = new PurchaseTransactionDetails();
   
    //        //foreach (var product in objPT.PurchaseTransactionDetails)
    //        //{
    //        //    objPT.customerId = Convert.ToInt32(frm["CustomerName"]);
    //        //    objPTD.ProductId = Convert.ToInt32(frm["ProductId"]);

    //        //    var ProdModelCust = Mapper.Map<PurchaseTransaction, PurchaseTransactionSummeries>(objPT);
    //        //    ProdModelCust.customerId = objPT.customerId;
    //        //    db.PurchaseTransactionSummery_Context.Add(ProdModelCust);
    //        //    db.SaveChanges();

    //        //    var prodModel = Mapper.Map<PurchaseTransaction, PurchaseTransactionDetails>(objPT);
    //        //    prodModel.PurchaseTransactionSummaryId = ProdModelCust.Id;
    //        //    prodModel.Quantity = product.Quantity;
    //        //    prodModel.Rate = product.Rate;
    //        //    prodModel.ProductId = product.ProductId;

    //        //    db.PurchaseTransactionDetails_Context.Add(prodModel);
    //        //    db.SaveChanges();
               
    //        //}
    //        return objPT;
    //    }
      
   // }
}