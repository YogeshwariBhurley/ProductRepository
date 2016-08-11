using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApplication.Models
{
    public class ProductCreateEditModel
    {
        public ProductCreateEditModel()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Rate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string ProductCategoryName { get; set; }
        //Navigation properties
        //public int ProductCategoryId { get; set; }
        public int ProductCategoryId{ get; set; }
        

        public virtual Entities.ProductCategories ProductCategoy { get; set; }

    }
}