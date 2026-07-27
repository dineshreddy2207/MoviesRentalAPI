using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class CustomerReadDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal MembershipFee { get; set; }
        public bool IsActive { get; set; }
        public DateTime MembershipDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
