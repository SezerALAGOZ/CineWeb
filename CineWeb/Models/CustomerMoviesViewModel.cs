using CineWeb.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineWeb.Models
{
    public class CustomerMoviesViewModel
    {
        public int CustomerId { get; set; }

        public ICollection<int> MovieIds { get; set; }
    }
}