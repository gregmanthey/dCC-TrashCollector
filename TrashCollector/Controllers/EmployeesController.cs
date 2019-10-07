using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext context;
        public EmployeesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employees
        public ActionResult Index()
        {
            string today = DateTime.Now.DayOfWeek.ToString();
            var todaysDate = DateTime.Now.Date;
            var customers = GetCustomersSharingZIP().Where(c => c.PickupDay == today).ToList();
            var pickupDateTodayCustomers = context.Customers.Where(c => c.PickupDate == todaysDate).ToList();
            customers.AddRange(pickupDateTodayCustomers);
            return View(customers);
        }
        public ActionResult ViewCustomersByPickupDay(string day)
        {
            var customers = GetCustomersSharingZIP().Where(c => c.PickupDay == day);
            return View(customers);
        }
        public ActionResult ConfirmPickup(int customerId)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == customerId);
            customer.AccountBalance += 12.17;
            customer.ChargedForPickupOn = DateTime.Now.Date;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            var employeeFoundInDb = GetEmployeeFromId(id);
            return View(employeeFoundInDb);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here

                employee.UserGuid = User.Identity.GetUserId();
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetEmployeeFromId(id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                var employeeFoundInDb = GetEmployeeFromId(id);
                employeeFoundInDb.FirstName = employee.FirstName;
                employeeFoundInDb.LastName = employee.LastName;
                employeeFoundInDb.ZIP = employee.ZIP;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetEmployeeFromId(id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                var employeeFoundInDb = GetEmployeeFromId(id);
                context.Employees.Remove(employeeFoundInDb);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private Employee GetEmployeeFromId(int id)
        {
            try
            {
                var foundEmployee = context.Employees.Find(id);
                return foundEmployee;
            }
            catch
            {
                throw new Exception("Employee not found");
            }
        }
        private Employee GetCurrentEmployee()
        {
            try
            {
                var currentUserGuid = User.Identity.GetUserId();
                var currentEmployee = context.Employees.SingleOrDefault(e => e.UserGuid == currentUserGuid);
                return currentEmployee;
            }
            catch
            {
                throw new Exception("Current user is not an employee");
            }
        }
        private IQueryable<Customer> GetCustomersSharingZIP()
        {
            var currentEmployee = GetCurrentEmployee();
            return context.Customers.Where(c => c.ZIP == currentEmployee.ZIP);
        }
    }
}
