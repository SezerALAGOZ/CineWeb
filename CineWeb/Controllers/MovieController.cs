using CineWeb.DomainEntities;
using CineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineWeb.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        // Gets the list of movies
        [HttpGet]
        public ActionResult Index()
        {
            var movies = _context.Movies.Include("Genre").ToList();
            if (User.IsInRole(RoleName.CanManageMovie))
            {
                
                return View(movies);
            }
            return View("IndexUser", movies);
        }

        // GET: /Movie/Create
        // Displays the form to create a movie. We want to select a genre for each movie. Therefore we send a ViewModel to View and hold a list of Genres so that we can hold them in a dropdown list.
        [HttpGet]
        public ActionResult Create()
        {
            var genreList = _context.Genres.ToList();

            var viewModel = new MovieGenreViewModel()
            {
                Movie = new Movie(), //We initialized ViewModel with a new Movie object so that it doesn't return null when POST method is called.
                Genres = genreList
            };

            return View(viewModel);
        }

        // POST: /Movie/Create
        // Add a new movie to database according to user-supplied model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Movie");
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }


        // GET: /movie/update/id
        // Gets the id of the movie to be updated and displays a update form with existing information of selected movie. 
        // id parameter's value comes from the url. Don't forget to add id attribute for link that supplies url.
        [HttpGet]
        public ActionResult Update(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.MovieId == id);
            if (movieInDb == null)
            {
                return HttpNotFound();
            }

            var viewModelToUpdate = new MovieGenreViewModel()
            {
                Movie = movieInDb,
                Genres = _context.Genres.ToList()
            };
            return View("Update", viewModelToUpdate);
        }


        // POST: /movie/update
        // Updates the selected movie in the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update", "Movie");

            }

            var movieInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);

            movieInDb.MovieName = movie.MovieName;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }


        // Delete: /Movie/Delete/id
        // Deletes the selected movie from database. MVC matches the movie id from the Url. Don't forget to add id attribute for link or form that supplies url.
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.MovieId == id);
            if (movieInDb == null)
            {
                return HttpNotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}