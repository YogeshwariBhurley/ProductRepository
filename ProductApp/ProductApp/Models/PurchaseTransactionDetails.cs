using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ProductApp.Models
{
    public class PurchaseTransactionDetails
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
        public virtual PurchaseTransactionSummeries PurchaseTransactionSummaryId { get; set; }
        [Required]
        public virtual Products ProductId { get; set; }
        public virtual List<Products> Products { get; set; }

    }
}