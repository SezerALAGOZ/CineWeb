using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CineWeb.DomainEntities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "At least 5, at most 50 characters.", MinimumLength = 5)]
        [Column("Customer Name")]
        public string CustomerName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [DataType(DataType.Date)]
        [Column("Date of Birth")]
        public DateTime? BirthDate { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}