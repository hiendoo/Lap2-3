using Lap2_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lap2_3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello !" + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML & CSS Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
            public ActionResult ListBookModel()
            {
                var books = new List<Book>();
                books.Add(new Book(1, "HTML5 & CSS3 The complete ", "Author Name Book 1", "Content/Images/doraemon.png"));
                books.Add(new Book(2, "HTML & CSS Responsive web Design cookbook", "Author Name Book 2", "Content/Images/nobita.jpg"));
                books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "Content/Images/son goku.jpg"));
                return View(books);
            }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]

        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete ", "Author Name Book 1", "Content/Images/doraemon.png"));
            books.Add(new Book(2, "HTML & CSS Responsive web Design cookbook", "Author Name Book 2", "Content/Images/nobita.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "Content/Images/Son goku.jpg"));
            if (id == null)
            {
                return HttpNotFound();
            }           
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);

        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "id , Title ,Author , ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTLM5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/Book1.jpg"));
            books.Add(new Book(2, "HTLM5 & CSS3 Responsive web Design cookbook ", " Author Name Book 2", "/Content/images/Book2.jpg"));
            books.Add(new Book(3, "Professional APS.NET  MVC5 ", " Author Name Book 3", "/Content/images/Book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {

                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            return View("ListBookModel", books);
        }

       
            
        
    }
}