using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Models;


namespace WebApiExample.Repositories
{
   public  interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookId);
        void InsertBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book , int BookId);
        void Save();
        void Dispose();
        
    }
}
