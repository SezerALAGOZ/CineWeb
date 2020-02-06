using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineWeb.DomainEntities
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Movie name is required.")]
        [Column("Movie Name")]
        public string MovieName { get; set; }

        [Column("Date of Release")]
        public string ReleaseDate { get; set; }

        [Column("Number in Stock")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

    }
}