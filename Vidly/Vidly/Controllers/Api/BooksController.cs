using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.Dtos;

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
        public IHttpActionResult GetBooks()
        {
            return Ok(_booksContext.Books.ToList().Select(Mapper.Map<Book, BookDto>));           
        }
        //GET /api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var books = _booksContext.Books.SingleOrDefault(b => b.Id == id);
            if (books == null)
                return NotFound();
            return Ok(Mapper.Map<Book, BookDto>(books));
           
        }
        //POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var books = Mapper.Map<BookDto, Book>(bookDto);

            _booksContext.Books.Add(books);
            _booksContext.SaveChanges();
            bookDto.Id = books.Id;
            return Created(new Uri(Request.RequestUri + "/" + books.Id), bookDto);
        }
        [HttpPut]
        //PUT /api/books
        public IHttpActionResult Update(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var bookInDb = _booksContext.Books.SingleOrDefault(c => c.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(bookDto, bookInDb);
            _booksContext.SaveChanges();
            return Ok();
        }
        //DELETE /api/books/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookinDb = _booksContext.Books.SingleOrDefault(b => b.Id == id);
            if (bookinDb == null)
            {
                return NotFound();
            }
            _booksContext.Books.Remove(bookinDb);
            _booksContext.SaveChanges();
            return Ok();
        }
    }
}
