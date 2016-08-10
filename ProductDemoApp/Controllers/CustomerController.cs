using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProductDemoApp.Context;
using ProductDemoApp.Models;
using System.Net;
using System.Data.Entity;

namespace ProductDemoApp.Controllers
{
    public class CustomerController : Controller
    {

        // GET: Customer
        ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            return View(db.Customer_Context.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers objCustomers)
        {

            if (ModelState.IsValid)
            {
                db.Customer_Context.Add(objCustomers);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objCustomers);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customer_Context.Find(id);
           
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "DateCreated,DateUpdated")] Customers objCustomers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objCustomers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCustomers);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            Customers customer = db.Customer_Context.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customer = db.Customer_Context.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customer = db.Customer_Context.Find(id);
            db.Customer_Context.Remove(customer);
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}