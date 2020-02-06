using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineWeb.DomainEntities
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public List<Movie> Movies { get; set; }

    }
}