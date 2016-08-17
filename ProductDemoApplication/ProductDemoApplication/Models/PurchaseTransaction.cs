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

        //Navigation Properties
        [Required]
        public int PurchaseTransactionSummaryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
        public int customerId { get; set; }
        public virtual Customers customer { get; set; }

        public int ProductCategoryId{get;set;}
        public virtual ProductCategories ProductCategory { get; set; }
    }
}