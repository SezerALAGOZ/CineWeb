using CineWeb.DomainEntities;
using CineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CineWeb.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(CustomerMoviesViewModel viewModel)
        {
            var customer = _context.Customers.Single(c => c.CustomerId == viewModel.CustomerId);

            //Defensive coding
            //var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == viewModel.CustomerId);

            //if (viewModel.MovieIds.Count == 0)
            //    return BadRequest("No movie Ids have been given.");

            var movies = _context.Movies.Where(m => viewModel.MovieIds.Contains(m.MovieId)).ToList();

            //Defensive coding
            //if (movies.Count != viewModel.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }


    }
}
