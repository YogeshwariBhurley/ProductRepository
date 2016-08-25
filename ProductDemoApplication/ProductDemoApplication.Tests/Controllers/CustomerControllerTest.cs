using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductDemoApplication.Servieces;
using ProductDemoApplication.Controllers;
using ProductDemoApplication.Models;
using ProductDemoApplication.Tests.AutoMapperCode;
using ProductDemoApplication.Context;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace ProductDemoApplication.Tests.Controllers
{
    [TestClass]
   public class CustomerControllerTest
    {
        CustomoerCreateEditModel objCC = new CustomoerCreateEditModel();
        CustomerService objCS = new CustomerService();
        [ClassInitialize]
        public static void Init(ProductContext context)
        {
            AutoMapperInit.Initialize();
        }
        [Fact]
        public void Index()
        {
            var showIndex = objCS.GetCustomer();
            Xunit.Assert.NotNull(showIndex);
        }
        [Fact]
        public void Create()
        {
            objCC.DateCreated = DateTime.Now;
            objCC.DateUpdated = DateTime.Now;
            objCC.Name = "Yogeshwari";
            var showCreate = objCS.GetCreatedCustomer(objCC);
            Xunit.Assert.NotNull(showCreate);
        }
        [Fact]        
        public void EditGet()
        {
           int id = 1;
            var GetValue = objCS.ShowEditedCustomer(id);            
            Xunit.Assert.NotNull(objCC);
        }
        [Fact]
        public void EditPost()
        {
            objCC.Id = 1;
            objCC.Name = "Yogesh";
            objCS.GetEditedCustomer(objCC);
            Xunit.Assert.NotNull(objCC);
        }
        [Fact]
        public void Details()
        {
            int id = 1;
            var showDetails = objCS.GetDetailedCustomer(id);
            Xunit.Assert.NotNull(showDetails);
        }

    }
}
