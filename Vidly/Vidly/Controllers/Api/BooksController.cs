using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _booksContext;
        public BooksController()
        {
            _booksContext = new ApplicationDbContext();
        }
        //GET /api/books
        public IEnumerable<Book> GetBooks()
        {
            var books = _booksContext.Books.ToList();
            return books;
        }
        //GET /api/books/1
        public Book GetBook(int id)
        {
            var books = _booksContext.Books.SingleOrDefault(b => b.Id == id);
            if (books == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return books;
        }
        //POST /api/books
        [HttpPost]
        public Book CreateBook(Book book)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _booksContext.Books.Add(book);
            _booksContext.SaveChanges();
            return book;
        }
        [HttpPut]
        //PUT /api/books
        public Book Update(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var bookInDb = _booksContext.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            bookInDb.ISBN = book.ISBN;
            bookInDb.Name = book.Name;
            bookInDb.NumberInStock = book.NumberInStock;
            bookInDb.DatePublished = book.DatePublished;
            bookInDb.AuthorName = book.AuthorName;
            _booksContext.SaveChanges();
            return book;
        }
        //DELETE /api/books/1
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookinDb = _booksContext.Books.SingleOrDefault(b => b.Id == id);
            if (bookinDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _booksContext.Books.Remove(bookinDb);
            _booksContext.SaveChanges();

        }
    }
}
