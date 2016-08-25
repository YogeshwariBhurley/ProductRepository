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
using System.Web.Mvc;

namespace ProductDemoApplication
{
    public class ProductService
    {
        ProductContext db = new ProductContext();
        public List<ProductCreateEditModel> GetProduct()
        {
            var product = from Products in db.Product_Context select Products;
            var prods = new List<ProductCreateEditModel>();
            if (product.Any())
            {
                foreach (var prod in product)
                {
                    ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(prod);
                    prods.Add(prodModel);
                }
            }
            return prods;
        }
        public ProductCreateEditModel GetCreatedProduct(ProductCreateEditModel objProduct)
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
            });
            var prodModel = Mapper.Map<ProductCreateEditModel, Products>(objProduct);
            db.Product_Context.Add(prodModel);
            db.SaveChanges();
            return objProduct;
        }
        public ProductCreateEditModel ShowEditedProduct(int? id)
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
            });
            var prodDetails = db.Product_Context.Find(id);           
            var prodModel = Mapper.Map<Products, ProductCreateEditModel>(prodDetails);          
            return prodModel;
        }
        public ProductCreateEditModel GetEditedProduct(ProductCreateEditModel objProduct)
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
            });
            var prodModel = Mapper.Map<ProductCreateEditModel, Products>(objProduct);
            db.Entry(prodModel).State = EntityState.Modified;
            db.SaveChanges();
            return objProduct;
        }
        public ProductCreateEditModel GetDetailedProduct(int? id)
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
            });
            var ProductDetails = db.Product_Context.Find(id);
            ProductCreateEditModel prodModel = Mapper.Map<Products, ProductCreateEditModel>(ProductDetails);
            return prodModel;
        }
        public ProductCreateEditModel ShowDeletedProduct(int? id)
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
            });
            var ProductDetails = db.Product_Context.Find(id);
            var prod = Mapper.Map<Products, ProductCreateEditModel>(ProductDetails);
            return prod;
        }
        public ProductCreateEditModel GetDeletedProduct(int id,ProductCreateEditModel objproduct)
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Products, ProductCreateEditModel>();
                cfg.CreateMap<ProductCreateEditModel, Products>();
            });
            var ProductDetails = db.Product_Context.Find(id);
            db.Product_Context.Remove(ProductDetails);
            db.SaveChanges();
            return objproduct;
        }
    }
}