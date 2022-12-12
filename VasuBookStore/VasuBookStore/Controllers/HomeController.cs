using Microsoft.AspNetCore.Mvc;

namespace VasuBookStore.Controllers
{
        public class HomeController:Controller
        {
            //public string Index()
            //{
            //    return "Sudhanshu";
            //}
                
        public ViewResult Index() 
        {

            //  return View(); // It is blank then it is calling itself, else ***  View(ViewName) *** , View(ViewName, object model) etc can call...;

            // IF WE WANT TO RETURN THE DIFFERENT VIEW ,THEN
            // ***CODE*** return View("AboutUs");

            //If we want to Bind the data from ***MODEL OBJECTS***

            var obj = new { Id = 1, Name = "Sudhanshu" };
            //return View(obj);

            //Want to call different model objects and different model
           // ***CODE*** return View("AboutUs", obj);

            // Return view from Other location 
            
            // 1) Full path.

            // ***CODE***  return View("TempView/VasuBookTemp.cshtml");

            //2 Relative path.
            //(../../)root/parent/Foldername/Filename without extension.
            return View("../../TempView/VasuBookTemp");
}

        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult WWWRootStatiFiles()
        {
            return View();
        }
        }

    
}
