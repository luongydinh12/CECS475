using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia57.Controllers
{
    [Route("blog57")]
    public class Blog57Controller : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog posts" };
        }

        [Route("{year57:min(2000)}/{month57:int}/{key}")]
        public IActionResult Post(int year57, int month57, string key)
        {
            return new ContentResult {
                Content = string.Format("Year: {0}; Month:{1}; Key: {2}", 
                year57, month57, key),
            };
        }
    }
}