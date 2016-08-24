using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDemoApplication.Models
{
    public class PurchaseTransactionReport
    {
        public int PurchaseTransactionSummaryId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }
        public string productCategoryName { get; set; }
    }
}