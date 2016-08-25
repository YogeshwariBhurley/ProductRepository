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
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
                cfg.CreateMap<Customers, CustomoerCreateEditModel>();
                cfg.CreateMap<CustomoerCreateEditModel, Customers>();
                cfg.CreateMap<PurchaseTransactionDetailsCreateEditDelete, PurchaseTransactionDetails>();
                cfg.CreateMap<PurchaseTransactionDetails, PurchaseTransactionDetailsCreateEditDelete>();
                cfg.CreateMap<PurchaseTransactionSummeries, PurchaseTransactionSummeriesCreateEdit>();
                cfg.CreateMap<PurchaseTransactionSummeriesCreateEdit, PurchaseTransactionSummeries>();

                cfg.CreateMap<PurchaseTransaction, PurchaseTransactionDetails>();
                cfg.CreateMap<PurchaseTransactionDetails, PurchaseTransaction>();
                cfg.CreateMap<PurchaseTransaction, PurchaseTransactionSummeries>();
                cfg.CreateMap<PurchaseTransactionSummeries, PurchaseTransaction>();
            });
           

        }
    }
}