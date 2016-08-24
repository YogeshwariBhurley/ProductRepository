using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Models;
using System.Web.Mvc;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Servieces
{
   public interface IPurchaseTransactionService
    {
        PurchaseTransaction GetCreatedPurchaseTransaction(PurchaseTransaction objPT);
        List<Products> GetProduct(int product);
        List<Products> FillRate(int prodctCat);
    }
}
