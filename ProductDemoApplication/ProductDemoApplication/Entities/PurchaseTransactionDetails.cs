﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApplication.Entities
{
    public class PurchaseTransactionDetails
    {
        public PurchaseTransactionDetails()
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

        //Navigation Properties
        [Required]
        public int PurchaseTransactionSummaryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }

    }
}