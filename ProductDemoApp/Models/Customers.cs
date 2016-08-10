using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApp.Models
{
    public class Customers
    {
        public Customers()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
      
    }
}