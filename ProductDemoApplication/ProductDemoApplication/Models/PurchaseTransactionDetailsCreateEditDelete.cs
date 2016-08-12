using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Models
{
    public class PurchaseTransactionDetailsCreateEditDelete
    {
        public int Id { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Navigation Properties
        [Required]
        public int PurchaseTransactionSummaryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Products Product { get; set; }

    }
}