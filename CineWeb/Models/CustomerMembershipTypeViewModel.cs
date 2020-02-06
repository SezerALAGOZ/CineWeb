using CineWeb.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineWeb.Models
{
    public class CustomerMembershipTypeViewModel
    {
        public CustomerMembershipTypeViewModel()
        {

        }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}