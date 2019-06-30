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
        private readonly BlogDataContext _db57;

        public Blog57Controller(BlogDataContext db57)
        {
            _db57 = db57;
        }

        [Route("")]
        public IActionResult Index()
        {
            var posts57 = _db57.Posts57.OrderByDescending(x => x.Posted57).Take(5).ToArray();
            return View(posts57);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = _db57.Posts57.FirstOrDefault(x => x.Key57 == key);
            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, Route("create")]
        public IActionResult Create(Post post57)
        {
            if (!ModelState.IsValid)
                return View();

            post57.Author57 = User.Identity.Name;
            post57.Posted57 = DateTime.Now;

            _db57.Posts57.Add(post57);
            _db57.SaveChanges();

            return RedirectToAction("Post","Blog57", new
            {
                year = post57.Posted57.Year,
                month = post57.Posted57.Month,
                key = post57.Key57
            });
        }


    }
}