using CineWeb.DomainEntities;
using CineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineWeb.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        // Displays the list of customers
        [HttpGet]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include("MembershipType").ToList();

            if (User.IsInRole(RoleName.CanManageMovie))
            {
                return View(customers);
            }
            return View("IndexUser", customers);
        }

        // GET: Customer Creation Form
        // Displays the form to create a customer
        // It sends a CustomerMembershipTypeViewModel to the View so that we can hold all the membership types in a dropdown list.
        [HttpGet]
        public ActionResult Create()
        {
            var membershipTypeList = _context.MembershipTypes.ToList();
            var viewModel = new CustomerMembershipTypeViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypeList
            };
            return View(viewModel);
        }

        // POST: /Customer/
        // Add a new customer to database according to user-supplied model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Create", "Customer");

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        // GET: /customer/update/id
        // Gets the id of the customer to be updated and displays a update form with existing information of selected customer. 
        // id parameter's value comes from the url. Don't forget to add id attribute for link that supplies url.
        [HttpGet]
        public ActionResult Update(int id)
        {
            var customerInDb = _context.Customers.Single(p => p.CustomerId == id);
            if (customerInDb == null)
            {
                return HttpNotFound();
            }

            var viewModelforUpdateForm = new CustomerMembershipTypeViewModel()
            {
                Customer = customerInDb,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("Update", viewModelforUpdateForm);
        }


        // POST: /customer/update
        // Updates the selected customer in the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update", "Customer");
            }

            var customerInDb = _context.Customers.Single(p => p.CustomerId == customer.CustomerId);

            if (customerInDb == null)
            {
                return HttpNotFound();
            }

            customerInDb.CustomerName = customer.CustomerName;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");

        }

        // Delete: /Customer/Delete/id
        // Deletes the selected customer from database. MVC matches the customer id from the Url. Don't forget to add id attribute for link or form that supplies url.
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.Single(p => p.CustomerId == id);

            if (customerInDb == null)
            {
                return HttpNotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}