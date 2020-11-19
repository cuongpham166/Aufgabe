using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieData.Data;
using MovieData.Models;

namespace MovieData.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Genre> genreList = _db.Genre;

            /*onsole.WriteLine("hihfdiofhdfhgdiofgdoifgd");
            foreach (var obj in genreList)
            {
                Console.WriteLine(obj.Name); //Type MovieData.Models.Genre
                Console.WriteLine(obj.Name.ToString());
            }*/

                
            return View(genreList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _db.Genre.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET-EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Genre.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        

        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Genre obj)
        {
            if (ModelState.IsValid)
            {
                _db.Genre.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete (int? id)
        {
            var obj = _db.Genre.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Genre.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}