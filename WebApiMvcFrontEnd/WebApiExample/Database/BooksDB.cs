using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiExample.Models;

namespace WebApiExample.Database
{
    public class BooksDB : DbContext
    {
        public BooksDB()
           : base("name=BooksDatabase")
        {
        }

        

        public DbSet<Book> Books { get; set; }
    }
}