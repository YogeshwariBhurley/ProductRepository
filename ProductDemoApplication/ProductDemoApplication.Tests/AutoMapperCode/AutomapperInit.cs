using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Models;
using ProductDemoApplication.Entities;

using AutoMapper;

namespace ProductDemoApplication.Tests.AutoMapperCode
{
   public class AutoMapperInit
    {
        public static void Initialize()
        {
         // var config=new MapperConfiguration(cfg =>
         Mapper.Initialize(cfg=>
            {
                cfg.CreateMissingTypeMaps = true;
               
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
                cfg.CreateMap<Customers, CustomoerCreateEditModel>();//.ReverseMap();
                cfg.CreateMap<CustomoerCreateEditModel, Customers>();//.ReverseMap();
                cfg.CreateMap<PurchaseTransactionDetailsCreateEditDelete, PurchaseTransactionDetails>();
                cfg.CreateMap<PurchaseTransactionDetails, PurchaseTransactionDetailsCreateEditDelete>();
                cfg.CreateMap<PurchaseTransactionSummeries, PurchaseTransactionSummeriesCreateEdit>();
                cfg.CreateMap<PurchaseTransactionSummeriesCreateEdit, PurchaseTransactionSummeries>();

                cfg.CreateMap<PurchaseTransaction, PurchaseTransactionDetails>();
                cfg.CreateMap<PurchaseTransactionDetails, PurchaseTransaction>();
                cfg.CreateMap<PurchaseTransaction, PurchaseTransactionSummeries>();
                cfg.CreateMap<PurchaseTransactionSummeries, PurchaseTransaction>();
            });

            //config.AssertConfigurationIsValid();
            //Mapper.Initialize(config);
        }
    }
}
