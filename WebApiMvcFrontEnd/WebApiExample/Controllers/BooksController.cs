                                                                                                                                                                                                                                                                                                                                                                                                                                                                 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiExample.Database;
using WebApiExample.Models;
using WebApiExample.Repositories;                                                                                                                                                                                                                                                                                                                                                                                                                                                                            

namespace WebApiExample.Controllers
{
    public class BooksController : ApiController
    {
        BooksDB db = new BooksDB();
        private IBookRepository _bookRepository;
        public BooksController()
        {
            _bookRepository = new BookRepository(new BooksDB());
        }
        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }



        // GET: api/Books
        public IEnumerable<Book> GetBooks()

        {
            return _bookRepository.GetBooks();


        }

        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)

        {
            Book book = _bookRepository.GetBookByID(id);
            //Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            

            try
            {
                _bookRepository.Save();
               // db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               
                
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookRepository.InsertBook(book);
            _bookRepository.Save();
           // db.Books.Add(book);
           // db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = _bookRepository.GetBookByID(id);
           // Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.DeleteBook(id);
            _bookRepository.Save();
           // db.Books.Remove(book);
           // db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookRepository.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}