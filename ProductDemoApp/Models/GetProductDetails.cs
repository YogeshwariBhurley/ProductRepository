using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProductDemoApp.Models;
using ProductDemoApp.Context;
using System.Web.Mvc;

namespace ProductDemoApp.Models
{
    public class GetProductDetails
    {
        ProductContext db = new ProductContext();
        public IList<ProductCategories> GetProduct()
        {
            return (from p in db.ProductCategories_Context select p).ToList();
        }

        public List<SelectListItem> GetProdName()
        {
            var ProductName = (from Products in db.ProductCategories_Context
                               select new SelectListItem
                               {
                                   Text = Products.Name,
                                   Value = Products.Id.ToString()

                               });
            return ProductName.ToList();
        }
    }
}