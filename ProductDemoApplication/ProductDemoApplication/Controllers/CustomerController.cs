using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApplication.Context;
using ProductDemoApplication.Models;
using System.Net;
using System.Data.Entity;
using AutoMapper;
namespace ProductDemoApplication.Controllers
{
    public class CustomerController : Controller
    {

        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            try
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
                return View(custs);
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomoerCreateEditModel objCustomers)
        {
            try
            {
                var custModel = Mapper.Map<CustomoerCreateEditModel, Customers>(objCustomers);
                db.Customer_Context.Add(custModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                var custDetails = db.Customer_Context.Find(id);
                var prodModel = Mapper.Map<Customers, CustomoerCreateEditModel>(custDetails);
                return View(prodModel);
            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] CustomoerCreateEditModel objCustomers)
        {
            try
            {
                var custModel = Mapper.Map<CustomoerCreateEditModel, Customers>(objCustomers);
                db.Entry(custModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Details(int? id)
        {
            try
            {
                var CustDetails = db.Customer_Context.Find(id);
                CustomoerCreateEditModel custModel = Mapper.Map<Customers, CustomoerCreateEditModel>(CustDetails);
                return View(custModel);
            }
            catch
            {
                return View();
            }


        }
        public ActionResult Delete(int? id)
        {
            try
            {
                var custDetails = db.Customer_Context.Find(id);
                var cust = Mapper.Map<Customers, CustomoerCreateEditModel>(custDetails);
                return View(cust);
            }
            catch
            {
                return View();
            }

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var custDetails = db.Customer_Context.Find(id);
                db.Customer_Context.Remove(custDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }
}