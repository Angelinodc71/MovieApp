using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movie_App.ViewModel;

namespace Movie_App.Controllers
{
    public class AppController : Controller
    {
        private static List<MovieViewModel> _movies = new List<MovieViewModel>();

        public object MessageBox { get; private set; }
        public object MessageBoxButtons { get; private set; }
        public object MessageBoxIcon { get; private set; }

        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult AddOrEdit(Guid id)
        {
            var movie = _movies.FirstOrDefault(x => x.id == id);
            return View();
        }

        [HttpPost]
        public IActionResult AddOrEdit(MovieViewModel model)
        {
            var movie = _movies.FirstOrDefault(x => x.id == model.id);

            if (ModelState.IsValid && movie == null) 
            {
                _movies.Add(model);
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                movie.genre = model.genre;
                movie.name = model.name;
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}