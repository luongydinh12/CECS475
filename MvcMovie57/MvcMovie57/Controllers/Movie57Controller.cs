using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie57.Models;

namespace MvcMovie57.Controllers
{
    public class Movie57Controller : Controller
    {
        private readonly MvcMovie57Context _context;

        public Movie57Controller(MvcMovie57Context context)
        {
            _context = context;
        }
        /*
        // GET: Movie57
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie57.ToListAsync());
        }*/

        /*
        //Example: https://localhost:44351/Movie57/Index/?searchString=Ghost
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movie57
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title57.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }
        */
        /*
        //Example: https://localhost:44351/Movie57/Index/ghost
        public async Task<IActionResult> Index(string id)
        {
            var movies = from m in _context.Movie57
                         select m;

            if (!String.IsNullOrEmpty(id))
            {
                movies = movies.Where(s => s.Title57.Contains(id));
            }

            return View(await movies.ToListAsync());
        }
        */
        // GET: Movies
        public async Task<IActionResult> Index(string movieGenre57, string searchString57)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery57 = from m in _context.Movie57
                                            orderby m.Genre57
                                            select m.Genre57;

            var movies = from m in _context.Movie57
                         select m;

            if (!string.IsNullOrEmpty(searchString57))
            {
                movies = movies.Where(s => s.Title57.Contains(searchString57));
            }

            if (!string.IsNullOrEmpty(movieGenre57))
            {
                movies = movies.Where(x => x.Genre57 == movieGenre57);
            }

            var movieGenreVM = new MovieGenreViewModel57
            {
                Genres57 = new SelectList(await genreQuery57.Distinct().ToListAsync()),
                Movies57 = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Movie57/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie57 = await _context.Movie57
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie57 == null)
            {
                return NotFound();
            }

            return View(movie57);
        }

        // GET: Movie57/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie57/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title57,ReleaseDate57,Genre57,Price57,Rating57")] Movie57 movie57)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie57);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie57);
        }

        // GET: Movie57/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie57 = await _context.Movie57.FindAsync(id);
            if (movie57 == null)
            {
                return NotFound();
            }
            return View(movie57);
        }

        // POST: Movie57/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title57,ReleaseDate57,Genre57,Price57")] Movie57 movie57)
        {
            if (id != movie57.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie57);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Movie57Exists(movie57.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie57);
        }

        // GET: Movie57/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie57 = await _context.Movie57
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie57 == null)
            {
                return NotFound();
            }

            return View(movie57);
        }

        // POST: Movie57/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie57 = await _context.Movie57.FindAsync(id);
            _context.Movie57.Remove(movie57);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Movie57Exists(int id)
        {
            return _context.Movie57.Any(e => e.Id == id);
        }
    }
}
