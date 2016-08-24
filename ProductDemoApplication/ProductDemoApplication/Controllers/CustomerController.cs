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

using ProductDemoApplication.Servieces;
namespace ProductDemoApplication.Controllers
{
    public class CustomerController : Controller
    {

        ProductContext db = new ProductContext();
        public ActionResult Index(CustomerService objCustService)
        {
            try
            {
               var custs= objCustService.GetCustomer();
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
        public ActionResult Create(CustomoerCreateEditModel objCustomers,CustomerService objCS)
        {
            try
            {
                objCS.GetCreatedCustomer(objCustomers);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id,CustomerService objCS)
        {
            try
            {
                var prodModel = objCS.ShowEditedCustomer(id);
                return View(prodModel);
            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] CustomoerCreateEditModel objCustomers,CustomerService objCS)
        {
            try
            {
                objCS.GetEditedCustomer(objCustomers);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Details(int? id,CustomerService objCS)
        {
            try
            {
               var custModel= objCS.GetDetailedCustomer(id);
               return View(custModel);
            }
            catch
            {
                return View();
            }


        }
        public ActionResult Delete(int? id,CustomerService objCS)
        {
            try
            {
                var cust=objCS.ShowDeletedCustomer(id);
                return View(cust);
            }
            catch
            {
                return View();
            }

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id,CustomerService objCS)
        {
            try
            {
                CustomoerCreateEditModel objCust = new CustomoerCreateEditModel();
                objCS.GetDeletedCustomer(id, objCust);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }
}