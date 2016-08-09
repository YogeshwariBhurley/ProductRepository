﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace ProductApp.Models
{
    public class PurchaseTransactionSummeries
    {
        public PurchaseTransactionSummeries()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Navigation Properties
        [Required]
        public virtual Customers customerId { get; set; }
        public virtual List<Customers> customer { get; set; }
    }
}