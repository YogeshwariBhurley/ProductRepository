using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Data.Entity;
using ProductApp.Models;

namespace ProductApp.Context
{
    public class ProductContext:DbContext
    {
        public DbSet<Products> Product_Context { get; set; }
        public DbSet<ProductCategories> ProductCategories_Context { get; set; }
        public DbSet<Customers> Customer_Context { get; set; }
        public DbSet<PurchaseTransactionSummeries> PurchaseTransactionSummery_Context { get; set; }
        public DbSet<PurchaseTransactionDetails> PurchaseTransactionDetails_Context { get; set; }

    }
}