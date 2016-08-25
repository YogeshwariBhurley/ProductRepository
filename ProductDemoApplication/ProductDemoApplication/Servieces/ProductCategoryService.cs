using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using ProductDemoApplication.Context;
using ProductDemoApplication.Models;
using System.Net;
using System.Data.Entity;
using ProductDemoApplication.Entities;

namespace ProductDemoApplication.Servieces
{
    public class ProductCategoryService:IProductCategoryService
    {
        ProductContext db = new ProductContext();
        public List<ProductCategoryCreateEditModel> GetCategory()
        {
            ProductCategoryCreateEditModel objproduct = new ProductCategoryCreateEditModel();
            var prodLists = from ProductCategories in db.ProductCategories_Context select ProductCategories;
            var Prods = new List<ProductCategoryCreateEditModel>();
            if (prodLists.Any())
            {
                foreach (var prod in prodLists)
                {

                    ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prod);
                    Prods.Add(prodModel);
                }
            }
            return Prods;
        }
        public ProductCategoryCreateEditModel GetCreatedCategory(ProductCategoryCreateEditModel objProductCategory)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
            });
                var prodModel = Mapper.Map<ProductCategoryCreateEditModel, ProductCategories>(objProductCategory);
            db.ProductCategories_Context.Add(prodModel);
            db.SaveChanges();
            return objProductCategory;
        }
        public ProductCategoryCreateEditModel ShowEditedCategory(int? id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
            });
            var prodDetails = db.ProductCategories_Context.Find(id);
             var prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(prodDetails);
            return prodModel;
        }
        public ProductCategoryCreateEditModel GetEditedCategory(ProductCategoryCreateEditModel objProductCategory)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
            });
            var prodModel = Mapper.Map<ProductCategoryCreateEditModel, ProductCategories>(objProductCategory);
            db.Entry(prodModel).State = EntityState.Modified;
            db.SaveChanges();
            return objProductCategory;
        }
        public ProductCategoryCreateEditModel GetDetailsCategory(int? id) 
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
            });
            var ProductCatDetails = db.ProductCategories_Context.Find(id);
            ProductCategoryCreateEditModel prodModel = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(ProductCatDetails);
            return prodModel;
        }
        public ProductCategoryCreateEditModel ShowDeletedCategory(int? id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
            });
            var ProductCatDetails = db.ProductCategories_Context.Find(id);
            var prod = Mapper.Map<ProductCategories, ProductCategoryCreateEditModel>(ProductCatDetails);
            return prod;
        }
        public ProductCategoryCreateEditModel GetDeletedCategory(int id, ProductCategoryCreateEditModel objProductCategory)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategories, ProductCategoryCreateEditModel>();
                cfg.CreateMap<ProductCategoryCreateEditModel, ProductCategories>();
            });
            var ProductCatDetails = db.ProductCategories_Context.Find(id);
            db.ProductCategories_Context.Remove(ProductCatDetails);
            db.SaveChanges();
            return objProductCategory;
        }
    }
}