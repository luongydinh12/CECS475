using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia57.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia57.Controllers
{
    [Route("blog57")]
    public class Blog57Controller : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            var posts = new[]
            {
                new Post
                {
                    Title57 = "My blog post",
                    Posted57 = DateTime.Now,
                    Author57 = "Jess Chadwick",
                    Body57 = "This is a great blog post, don't you think?",
                },
                new Post
                {
                    Title57 = "My second blog post",
                    Posted57 = DateTime.Now,
                    Author57 = "Jess Chadwick",
                    Body57 = "This is ANOTHER great blog post, don't you think?",
                },
            };
            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post
            {
                Title57 = "My Blog Post",
                Posted57 = DateTime.Now,
                Author57 = "Jess Chadwick",
                Body57 = "This is a great blog post, don't you think?",
            };
            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            post.Author57 = User.Identity.Name;
            post.Posted57 = DateTime.Now;


            return View();
        }


    }
}