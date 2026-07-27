using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class RentalReadDto
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal RentalPrice { get; set; }
        public decimal LateFee { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
