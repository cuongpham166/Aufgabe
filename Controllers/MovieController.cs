using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieData.Data;
using MovieData.Models;
using MovieData.ViewsModels;

namespace MovieData.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private object eventStructureBLL;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Movie> movieList = _db.Movie;
            
            return View(movieList);
        }

        //GET-Create
        public IActionResult Create()
        {
            IEnumerable<Genre> genreList = _db.Genre;
            Console.WriteLine("hihfdiofhdfhgdiofgdoifgd");
            MovieDetailViewModel movieViewModel = new MovieDetailViewModel();
            movieViewModel.Genres = new List<string>();
            foreach (var obj in genreList)
            {
                movieViewModel.Genres.Add(obj.Name.ToString());
            }
            Console.WriteLine(movieViewModel.Genres);
            return View(movieViewModel);
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie obj)
        {
            MovieDetailViewModel movieViewModel = new MovieDetailViewModel();
            if (ModelState.IsValid)
            {
                _db.Movie.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}