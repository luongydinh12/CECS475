/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUnitTestingDemo57.Controllers
{
    public class Employee57Controller : Controller
    {
        // GET: Employee57
        public ActionResult Index()
        {
            return View();
        }
    }
}*/

using MVCUnitTestingDemo57.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace MVCUnitTestingDemo57.Controllers
{
    public class Employee57Controller : Controller
    {
        [NonAction]

        public List<Employee57> GetEmployeeList()
        {
            return new List<Employee57>{
            new Employee57{
               ID = 1,
               Name57 = "Allan",
               JoiningDate57 = DateTime.Parse(DateTime.Today.ToString()),
               Age57 = 23
            },

            new Employee57{
               ID = 2,
               Name57 = "Carson",
               JoiningDate57 = DateTime.Parse(DateTime.Today.ToString()),
               Age57 = 45
            },

            new Employee57{
               ID = 3,
               Name57 = "Carson",
               JoiningDate57 = DateTime.Parse(DateTime.Today.ToString()),
               Age57 = 37
            },

            new Employee57{
               ID = 4,
               Name57 = "Laura",
               JoiningDate57 = DateTime.Parse(DateTime.Today.ToString()),
               Age57 = 26
            },
         };
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            var employees57 = from e57 in GetEmployeeList()
                            orderby e57.ID
                            select e57;
            return View(employees57);
        }
    }
}