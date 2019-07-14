using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _bookContext;
        public BookController()
        {
            _bookContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _bookContext.Dispose();
        }
        // GET: Book
        public ActionResult Index()
        {
            var books = _bookContext.Books.ToList();
            if (User.IsInRole("CanManageBooks"))
            {
                return View("BookList", books);
            }
            return View("ReadOnlyBookList", books);
        }
        public ActionResult Details(int id)
        {
            var books = _bookContext.Books.SingleOrDefault(b => b.Id == id);
            return View(books);
        }
        [Authorize(Roles = "CanManageBooks")]
        public ActionResult BookForm()
        {
            return View();
        }
        public ActionResult Save(Book book)
        {
            if (book.Id == 0)
            {
                var books = _bookContext.Books.Add(book);
            }
            else
            {
                var bookInDb = _bookContext.Books.Single(b => b.Id == book.Id);
                bookInDb.ISBN = book.ISBN;
                bookInDb.Name = book.Name;
                bookInDb.NumberInStock = book.NumberInStock;
                bookInDb.DatePublished = book.DatePublished;
                bookInDb.AuthorName = book.AuthorName;
            }
            
            _bookContext.SaveChanges();
            return RedirectToAction("Index", "Book");
        }
        public ActionResult Edit(int id)
        {
            var books = _bookContext.Books.SingleOrDefault(b => b.Id == id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View("BookForm", books);

        }
    }
}