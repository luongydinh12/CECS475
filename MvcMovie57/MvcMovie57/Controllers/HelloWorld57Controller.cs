/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie57.Controllers
{
    public class HelloWorld57Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}*/
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie57.Controllers
{
    public class HelloWorld57Controller : Controller
    {
        /*
        // 
        // GET: /HelloWorld57/

        public string Index57()
        {
            return "This is my default action...";
        }
        */
        /*
        // 
        // GET: /HelloWorld57/Welcome57/ 

        public string Welcome57()
        {
            return "This is the Welcome action method...";
        }
        */
        /*
        // GET: /HelloWorld57/Welcome57/ 
        // Requires using System.Text.Encodings.Web;
        // Example: https://localhost:44351//HelloWorld57/Welcome57?name=Rick&numtimes=4
        public string Welcome57(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        */
        /*
        //Example: https://localhost:44351//HelloWorld57/Welcome57/3?name=Rick
        public string Welcome57(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
        */
        public IActionResult Index()
        {
            return View();
        }

        //Example: https://localhost:44351/HelloWorld57/Welcome57?name=Rick&numtimes=4
        public IActionResult Welcome57(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}