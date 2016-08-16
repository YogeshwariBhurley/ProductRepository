using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Models
{
    public class PurchaseTransactionList
    {
        public double Rate { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}