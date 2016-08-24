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
    public class CustomerService
    {
        ProductContext db = new ProductContext();
        public List<CustomoerCreateEditModel> GetCustomer()
        {

            var cusotmer = from Customers in db.Customer_Context select Customers;
            var custs = new List<CustomoerCreateEditModel>();
            if (cusotmer.Any())
            {
                foreach (var cust in cusotmer)
                {
                    CustomoerCreateEditModel custModel = Mapper.Map<Customers, CustomoerCreateEditModel>(cust);
                    custs.Add(custModel);
                }
            }
            return custs;
        }
        public CustomoerCreateEditModel GetCreatedCustomer(CustomoerCreateEditModel objCustomers)
        {
            var custModel = Mapper.Map<CustomoerCreateEditModel, Customers>(objCustomers);
            db.Customer_Context.Add(custModel);
            db.SaveChanges();
            return objCustomers;
        }
        public CustomoerCreateEditModel ShowEditedCustomer(int? id)
        {
            var custDetails = db.Customer_Context.Find(id);
            var prodModel = Mapper.Map<Customers, CustomoerCreateEditModel>(custDetails);
            return prodModel;
        }
        public CustomoerCreateEditModel GetEditedCustomer(CustomoerCreateEditModel objCustomers)
        {
            var custModel = Mapper.Map<CustomoerCreateEditModel, Customers>(objCustomers);
            db.Entry(custModel).State = EntityState.Modified;
            db.SaveChanges();
            return objCustomers;
        }
        public CustomoerCreateEditModel GetDetailedCustomer(int?id)
        {
            var CustDetails = db.Customer_Context.Find(id);
            CustomoerCreateEditModel custModel = Mapper.Map<Customers, CustomoerCreateEditModel>(CustDetails);
            return custModel;
        }
        public CustomoerCreateEditModel ShowDeletedCustomer(int? id)
        {
            var custDetails = db.Customer_Context.Find(id);
            var cust = Mapper.Map<Customers, CustomoerCreateEditModel>(custDetails);
            return cust;
        }
        public CustomoerCreateEditModel GetDeletedCustomer(int id,CustomoerCreateEditModel objcust)
        {
            var custDetails = db.Customer_Context.Find(id);
            db.Customer_Context.Remove(custDetails);
            db.SaveChanges();
            return objcust;
        }
        
    }
}