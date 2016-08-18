using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Models
{
    public class PurchaseTransaction
    {
        public PurchaseTransaction()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            PurchaseTransactionDetails = new List<PurchaseTransactionDetail>();
        }
        //public int Id { get; set; }

        //public double Rate { get; set; }

        //public int Quantity { get; set; }
        //public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }

        //public string CustomerName { get; set; }
        //public string ProductCategoryName { get; set; }
        //public string ProductName { get; set; }


        //Navigation Properties

        //public int PurchaseTransactionSummaryId { get; set; }

        //public int ProductId { get; set; }
        //public virtual Products Product { get; set; } 
        //public int customerId { get; set; }
       
        public int Id { get; set; }

        public int customerId { get; set; }
        public string CustomerName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual Customers customer { get; set; }
        public List<PurchaseTransactionDetail> PurchaseTransactionDetails { get; set; }
    }
    public class PurchaseTransactionDetail
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public string ProductCategoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}