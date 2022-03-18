using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExample.Models;
using WebApiExample.Database;
using System.Data.Entity;

namespace WebApiExample.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BooksDB _context;
        public BookRepository(BooksDB booksDb)
        {
            _context = booksDb;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookByID(int id)
        {
            return _context.Books.Find(id);
        }
        public void InsertBook(Book book)
        {
            _context.Books.Add(book);
        }
        public void DeleteBook(int bookID)
        {
            Book book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
        }
        public void UpdateBook(Book book, int id)
        {
            _context.Entry(book).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}