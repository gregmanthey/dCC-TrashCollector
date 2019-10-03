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
            return View(context.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customerFoundInDb = GetCustomerFromId(id);
            return View(customerFoundInDb);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            //Customer customer = new Customer();
            return View(new Customer());
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
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
            return View(GetCustomerFromId(id));
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
            return context.Customers.Find(id);
        }
        private ApplicationUser GetUserFromGuid(string userGuid)
        {
            return context.Users.Find(userGuid);
        }
    }
}
