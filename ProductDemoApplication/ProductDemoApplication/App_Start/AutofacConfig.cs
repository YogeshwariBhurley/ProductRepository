using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;
using Autofac.Integration.Mvc;
using ProductDemoApplication.Models;
using ProductDemoApplication.Servieces;
using System.Web.Mvc;

namespace ProductDemoApplication.App_Start
{
    public static class AutofacConfig
    {
        public static void Configuration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>();     
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var builderCust = new ContainerBuilder();        
            builder.RegisterType<CustomerService>().As<ICustomerService>();           
            var containerCust = builderCust.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerCust));

            var builderproduct = new ContainerBuilder();
            builder.RegisterType<ProductService>().As<IProduct>();
            var containerProduct = builderproduct.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerProduct));

            //var builderPurchaseTransaction = new ContainerBuilder();
            //builder.RegisterType<PurchaseTransactionService>().As<IPurchaseTransactionService>();
            //var containerPurchaseTransaction = builderPurchaseTransaction.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(containerPurchaseTransaction));

        }
    }
}