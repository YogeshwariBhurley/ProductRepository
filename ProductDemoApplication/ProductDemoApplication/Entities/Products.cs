﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApplication.Entities
{
    public class Products
    {
        //public Products()
        //{
        //    DateCreated = DateTime.Now;
        //    DateUpdated = DateTime.Now;
        //}
        //public int Id { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public double Rate { get; set; }
        //public DateTime DateCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        //public int ProductCategoryId { get; set; }
        //public virtual ProductCategories ProductCategory { get; set; }
        //Navigation properties
        //public int ProductCategoryId { get; set; }

        //  public virtual List<ProductCategories> ProductCategories { get; set; }

        //public virtual Product ProductCategory { get; set; }
        public Products()
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

        //Navigation properties
        //public int ProductCategoryId { get; set; }
        public int ProductCategoryId { get; set; }
        //  public virtual List<ProductCategories> ProductCategories { get; set; }
        public virtual ProductCategories ProductCategory { get; set; }

    }
}