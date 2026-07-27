using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class MovieReadDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public int DurationInMinutes { get; set; }
        public decimal RentalPrice { get; set; }
        public int AvailableStock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
