﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var userGuid = User.Identity.GetUserId();
            var customer = GetCustomerFromGuid(userGuid);
            return View("Details", "_LayoutCustomer", customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customerFoundInDb = GetCustomerFromId(id);
            return View("Details", "_LayoutCustomer", customerFoundInDb);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                customer.UserGuid = User.Identity.GetUserId();
                context.Customers.Add(customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Edit", "_LayoutCustomer", GetCustomerFromId(id));
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var customerFoundInDb = GetCustomerFromId(id);
                customerFoundInDb.FirstName = customer.FirstName;
                customerFoundInDb.LastName = customer.LastName;
                customerFoundInDb.StreetAddress = customer.StreetAddress;
                customerFoundInDb.City = customer.City;
                customerFoundInDb.State = customer.State;
                customerFoundInDb.ZIP = customer.ZIP;
                customerFoundInDb.PickupDay = customer.PickupDay;
                customerFoundInDb.PickupDate = customer.PickupDate;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPickupDate()
        {
            var userGuid = User.Identity.GetUserId();
            var customer = GetCustomerFromGuid(userGuid);
            return View("EditPickupDate", "_LayoutCustomer", customer);
        }

        [HttpPost]
        public ActionResult EditPickupDate(int id, Customer customer)
        {
            
            return Edit(id, customer);
        }
        public ActionResult EditPickupDay()
        {
            var userGuid = User.Identity.GetUserId();
            var customer = GetCustomerFromGuid(userGuid);
            return View("EditPickupDay", "_LayoutCustomer", customer);
        }

        [HttpPost]
        public ActionResult EditPickupDay(int id, Customer customer)
        {

            return Edit(id, customer);
        }
        public ActionResult EditSuspendDates()
        {
            var userGuid = User.Identity.GetUserId();
            var customer = GetCustomerFromGuid(userGuid);
            return View("EditSuspendDates", "_LayoutCustomer", customer);
        }

        [HttpPost]
        public ActionResult EditSuspendDates(int id, Customer customer)
        {

            return Edit(id, customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetCustomerFromId(id));
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                var customerFoundInDb = GetCustomerFromId(id);
                context.Customers.Remove(customerFoundInDb);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private Customer GetCustomerFromId(int id)
        {
            try
            {
                var foundCustomer = context.Customers.Find(id);
                return foundCustomer;
            }
            catch
            {
                throw new Exception("Customer not found");
            }
        }
        private Customer GetCustomerFromGuid(string guid)
        {
            try
            {
                var foundCustomer = context.Customers.SingleOrDefault(c => c.UserGuid == guid);
                return foundCustomer;
            }
            catch
            {
                throw new Exception("Customer not found");
            }
        }
    }
}
