using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;

namespace Mvc.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            IEnumerable<BookModel> booksList;
            HttpResponseMessage response = GlobalVar._httpClient.GetAsync("Books ").Result;
            booksList = response.Content.ReadAsAsync<IEnumerable<BookModel>>().Result;
            return View(booksList);
        }
        public ActionResult AddBook(int id = 0)
        {
            if (id == 0)

                return View(new BookModel());
            else
            {
                HttpResponseMessage response = GlobalVar._httpClient.GetAsync("Books/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<BookModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddBook(BookModel book)

        {
            if(book.Id==0)
            
            {

                HttpResponseMessage response = GlobalVar._httpClient.PostAsJsonAsync("Books", book).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVar._httpClient.PutAsJsonAsync("Books/" + book.Id, book).Result;
            }


            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id = 0)
        {

            HttpResponseMessage response = GlobalVar._httpClient.DeleteAsync("Books/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
        //[HttpPut]
        //public ActionResult UpdateBook(BookModel book   )

        //{

        //    {
        //        HttpResponseMessage response = GlobalVar._httpClient.PutAsJsonAsync("Bookss/" + book.Id, book).Result;
        //    }


        //    return RedirectToAction("Index");
        //}

    }
}