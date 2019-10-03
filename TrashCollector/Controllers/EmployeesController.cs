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
            return View(context.Employees.ToList());
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
            //Employee employee = new Employee();
            return View(new Employee());
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
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
        private ApplicationUser GetUserFromGuid(string userGuid)
        {
            try
            {
                var foundUser = context.Users.Find(userGuid);
                return foundUser;
            }
            catch
            {
                throw new Exception("User not found");
            }
        }
    }
}
