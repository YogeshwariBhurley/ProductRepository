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

namespace ProductDemoApplication.Tests.Controllers
{
    public class ProductControllerTest
    {
        [ClassInitialize]
        public static void Init(ProductContext context)
        {
            AutoMapperInit.Initialize();
        }
        ProductCreateEditModel objPC = new ProductCreateEditModel();
        ProductService objPS = new ProductService();
        [Fact]
        public void Index()
        {
            var showIndex = objPS.GetProduct();
            Xunit.Assert.NotNull(showIndex);
        }
        [Fact]
        public void Create()
        {
            objPC.Name = "Harry Potter-7";
            objPC.DateCreated = DateTime.Now;
            objPC.DateUpdated = DateTime.Now;
            objPC.ProductCategoryId = 3;
            objPC.Rate = 400;
            var showCreate = objPS.GetCreatedProduct(objPC);
            Xunit.Assert.NotNull(showCreate);
        }

        [Fact]
        public void EditGet()
        {
            int id = 1;
            objPS.ShowEditedProduct(id);
            Xunit.Assert.NotNull(objPC);
            // Xunit.Assert.Throws<ArgumentException>(() => objPS.ShowEditedProduct(id));
        }
        [Fact]
        public void EditPost()
        {
            objPC.Id = 1;
            objPC.Name = "Accessories";
            objPS.GetEditedProduct(objPC);
            Xunit.Assert.NotNull(objPC);
        }
        [Fact]
        public void Details()
        {
            int id = 1;
            var showDetails = objPS.GetDetailedProduct(id);
            Xunit.Assert.NotNull(showDetails);
        }
    }
}
