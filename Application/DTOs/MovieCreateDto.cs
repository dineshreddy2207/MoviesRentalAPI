using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class MovieCreateDto
    {
        [Required(ErrorMessage = "Movie title is required")]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Release year is required")]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600)]
        public int DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Rental price is required")]
        [Range(0.01, 100)]
        public decimal RentalPrice { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0, 10000)]
        public int AvailableStock { get; set; }
    }
}
