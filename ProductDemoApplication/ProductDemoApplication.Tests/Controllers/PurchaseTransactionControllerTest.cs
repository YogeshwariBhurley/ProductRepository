using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Servieces;
using ProductDemoApplication.Controllers;
using ProductDemoApplication.Models;
using ProductDemoApplication.Tests.AutoMapperCode;
using ProductDemoApplication.Context;
using System.Web.Mvc;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductDemoApplication.Tests.Controllers
{
  public class PurchaseTransactionControllerTest
    {
        [ClassInitialize]
        public static void Init(ProductContext context)
        {
            AutoMapperInit.Initialize();
        }
        PurchaseTransaction objPT =new PurchaseTransaction();
        PurchaseTransactionService objPTS = new PurchaseTransactionService();
        FormCollection frm = new FormCollection();
        [Fact]
        public void Index()
        {
            var showCreate = objPTS.GetCreatedPurchaseTransaction(objPT,frm);
            Xunit.Assert.NotNull(showCreate);
        }
        
    }
}
