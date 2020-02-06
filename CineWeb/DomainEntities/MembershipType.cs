using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineWeb.DomainEntities
{
    public class MembershipType
    {
        public byte MembershipTypeId { get; set; }

        [Required(ErrorMessage = "Membership Type is required.")]
        public string MembershipTypeName { get; set; }

        [DataType(DataType.Currency)]
        public short SignUpFee { get; set; }

        [DataType(DataType.Date)]
        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public List<Customer> Customers { get; set; }
    }
}