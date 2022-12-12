using Microsoft.AspNetCore.Mvc;
using VasuBookStore.Repository;
using VasuBookStore.Models;

namespace VasuBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        //**** USE BOOKMODEL CLASS HERE ******
        
        // 1) We defined the repository.

        private readonly BookRepository _bookRepository= null;


        public BookStoreController()
        {
            _bookRepository = new BookRepository();
        }
            
        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        //Call this method and return **** VIEW() ****.
        //For that we weill use ***** ViewResult() ***** to return the view. 
        
        public ViewResult GetBooksDetail()
        {
            var data = _bookRepository.GetAllBooks();
            return View();  
        }
        //public string GetAllBooks()
        //{
        //    return "All Books";
        //}

        public BookModel GetBookWithID(int ID)
        {
            return _bookRepository.GetBookByID(ID);
        }

        //public string GetBook(int id) // To run this [In startup.cs] , (endpoints.MapDefaultControllerRoute()) method will call.
        //                             // Inside this , If we don't define the route --> By Default route is {Controller=name}/{action=Index}/id?
        //{
        //    // return "Book" +" " +  id;   OR
        //    return $" Book with id:{id}"; 
        //}   

        public List<BookModel> SearchBookDetails(string TITLE, string AUTHORNAME)
        {
            return _bookRepository.SearchBooks(TITLE, AUTHORNAME);
        }
        //public string SearchBooks(string Bookname, string authorname)
        //{
        //    return $"Book name is :{Bookname} and Author Name is : {authorname}";
        //}

        public ViewResult BootstrapAndJquery()
        {
            return View();
        }
    }

}
