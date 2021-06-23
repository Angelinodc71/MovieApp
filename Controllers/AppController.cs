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

            if (ModelState.IsValid) 
            {
                if (movie == null) 
                {
                    model.id = Guid.NewGuid();
                    _movies.Add(model);
                }
                else 
                {
                    movie.genre = model.genre;
                    movie.name = model.name;
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Delete(Guid id) 
        {
            _movies.Remove(_movies.FirstOrDefault(x => x.id == id));
            return RedirectToAction(nameof(Index));
        }
    }
}