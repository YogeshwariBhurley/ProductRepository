using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using ProductDemoApplication.Models;
using System.Web.Mvc;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Product_Context { get; set; }
        public DbSet<ProductCategories> ProductCategories_Context { get; set; }
        public DbSet<Customers> Customer_Context { get; set; }
        public DbSet<PurchaseTransactionSummeries> PurchaseTransactionSummery_Context { get; set; }
        public DbSet<PurchaseTransactionDetails> PurchaseTransactionDetails_Context { get; set; }

        public System.Data.Entity.DbSet<ProductDemoApplication.Models.ProductCategoryCreateEditModel> ProductCategoryCreateEditModels { get; set; }

        public System.Data.Entity.DbSet<ProductDemoApplication.Models.ProductCategoryListModel> ProductCategoryListModels { get; set; }

        public System.Data.Entity.DbSet<ProductDemoApplication.Models.ProductCreateEditModel> ProductCreateEditModels { get; set; }

        public System.Data.Entity.DbSet<ProductDemoApplication.Models.CustomoerCreateEditModel> CustomoerCreateEditModels { get; set; }

        public System.Data.Entity.DbSet<ProductDemoApplication.Models.PurchaseTransactionDetailsCreateEditDelete> PurchaseTransactionDetailsCreateEditDeletes { get; set; }

        public System.Data.Entity.DbSet<ProductDemoApplication.Models.PurchaseTransaction> PurchaseTransactions { get; set; }

        

    }
    
}
