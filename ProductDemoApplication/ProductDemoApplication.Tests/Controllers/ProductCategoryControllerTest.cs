using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProductDemoApplication.Servieces;
using ProductDemoApplication.Controllers;
using ProductDemoApplication.Models;
using ProductDemoApplication.Tests.AutoMapperCode;
using ProductDemoApplication.Context;
using Xunit;

namespace ProductDemoApplication.Tests.Controllers
{
    [TestClass]
  
        public class ProductCategoryControllerTest
    {
        [ClassInitialize]
        public static void Init(ProductContext context)
        {
            AutoMapperInit.Initialize();
        }

        ProductCategoryService objPCS = new ProductCategoryService();
        ProductCategoryCreateEditModel objProductCategory = new ProductCategoryCreateEditModel();

        [Fact]
        public void Index()
        {            
            var showIndex = objPCS.GetCategory();
            Xunit.Assert.NotNull(showIndex);
        }
        [Fact]
        public void Create()
        {
            objProductCategory.Id = 1;
            objProductCategory.DateCreated = DateTime.Now;
            objProductCategory.DateUpdated = DateTime.Now;
            objProductCategory.Name = "Grocessory";
            var showCreate = objPCS.GetCreatedCategory(objProductCategory);
            Xunit.Assert.NotNull(showCreate);
        }
        [Fact]
        public void EditGet()
        {          
            int id = 1;            
            objPCS.ShowEditedCategory(id);
            Xunit.Assert.NotNull(objProductCategory);
          
        }
        [Fact]
        public void EditPost()
        {
            objProductCategory.Id = 1;
            objProductCategory.Name = "Accessories";
           
            objPCS.GetEditedCategory(objProductCategory);
            Xunit.Assert.NotNull(objProductCategory);
        }
        [Fact]
        public void Details()
        {
            int id = 1;
            var showDetails = objPCS.GetDetailsCategory(id);
            Xunit.Assert.NotNull(showDetails);
        }
        [Fact]
        public void DeleteGet()
        {
            int id = 1;
            objProductCategory.Id = 1;
            objProductCategory.Name = "Accessories";
            objProductCategory.DateCreated = DateTime.Now;
            objProductCategory.DateUpdated = DateTime.Now;
            var GetDeleted = objPCS.GetDeletedCategory(id, objProductCategory);
            Xunit.Assert.NotNull(objProductCategory);
        }

        public void DeletePost()
        {

        }
    }
}
