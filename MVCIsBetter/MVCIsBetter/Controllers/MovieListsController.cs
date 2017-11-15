using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCIsBetter.Models;

namespace MVCIsBetter.Controllers
{
    public class MovieListsController : Controller
    {
        private readonly TestContext db = new TestContext();

       

        // GET: MovieLists
        public async Task<IActionResult> Index()
        {
            return View(await db.MovieList.ToListAsync());
        }

        // GET: MovieLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieList = await db.MovieList
                .SingleOrDefaultAsync(m => m.Id == id);
            if (movieList == null)
            {
                return NotFound();
            }

            return View(movieList);
        }

        public IActionResult Create()
        {

            return View();
        }

        public async Task<IActionResult> Create([Bind("Id,MovieName,Genre,Rating,ReleaseYear,ImdbLink")] MovieList movieList)
        {
            if (ModelState.IsValid)
            {
                db.Add(movieList);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieList);
        }

    }
}
