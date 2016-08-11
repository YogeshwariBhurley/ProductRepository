﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ProductDemoApplication.Models
{
    public class ProductListModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}