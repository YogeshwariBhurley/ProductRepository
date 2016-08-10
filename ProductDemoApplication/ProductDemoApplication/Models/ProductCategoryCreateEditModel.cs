using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApplication.Models
{
    public class ProductCategoryCreateEditModel
    {
        public ProductCategoryCreateEditModel()
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