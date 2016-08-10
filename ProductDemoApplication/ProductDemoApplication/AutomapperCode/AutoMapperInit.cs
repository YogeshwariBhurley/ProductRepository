using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using ProductDemoApplication.Models;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.AutomapperCode
{
    public class AutoMapperInit
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
            });
        }
    }
}