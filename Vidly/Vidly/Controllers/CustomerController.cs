using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
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
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            NewCustomerViewModel ViewModel = new NewCustomerViewModel { MembershipTypes = membershipTypes };
            return View(ViewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewCustomerViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = _context.membershipTypes.ToList()
            //    };
            //    return View("CustomerForm", viewModel);
            //}

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
               var customerInDb =  _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.Name = customer.Name;
                customerInDb.NationalId = customer.NationalId;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id );
            if (customer == null)
            {
                return HttpNotFound();
            }
            NewCustomerViewModel viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("customerForm", viewModel);
        }

    }
}