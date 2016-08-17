using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Models
{
    public class PurchaseTransaction
    {
        public PurchaseTransaction()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string CustomerName { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductName { get; set; }
        public int PurchaseTransactionSummaryIdId { get; set; }

        //Navigation Properties
        [Required]
        public int PurchaseTransactionSummaryId { get; set; }
     
        public int ProductId { get; set; }
        public virtual Products Product { get; set; } 
        public int customerId { get; set; }
        public virtual Customers customer { get; set; }
    }
}