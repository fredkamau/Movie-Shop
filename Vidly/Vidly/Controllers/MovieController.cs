using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _MovieContext;
        public MovieController()
        {
            _MovieContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _MovieContext.Dispose();    
        }
        // GET: Employee
        public ActionResult Index()
        {
            var movies = _MovieContext.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _MovieContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie); 

        }
    }
}