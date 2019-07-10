using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Movie m1 = new Movie { Id=1, Name="Titanic"};
            var customer = new List<Customer>
            {
                new Customer { Name = "Fred" },
                new Customer { Name = "Kyle" }
            };
            MovieCustomerViewModel mcv = new MovieCustomerViewModel
            {
                Customers = customer,
                Movies = m1
            };
            return View(mcv);
        }
    }
}