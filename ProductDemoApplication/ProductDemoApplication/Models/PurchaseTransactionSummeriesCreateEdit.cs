using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApplication.Models
{
    public class PurchaseTransactionSummeriesCreateEdit
    {
        public PurchaseTransactionSummeriesCreateEdit()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

       

        //Navigation Properties
        [Required]
        public int customerId { get; set; }
        public virtual Customers customer { get; set; }
    }
}