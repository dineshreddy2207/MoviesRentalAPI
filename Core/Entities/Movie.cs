using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title cannot exceed 100 characters.")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description cannot exceed 500 characters.")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Release year is required.")]
        [Range(1900, 2100, ErrorMessage = "Release year must be between 1900 and 2100.")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public String Genre { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int DurationInMinutes { get; set; }

        [Required(ErrorMessage = "Rental price is required")]
        [Range(0.01, 100, ErrorMessage = "Rental price must be between 0.01 and 100")]
        public decimal RentalPrice { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, 10000, ErrorMessage = "Stock must be between 0 and 10000")]
        public int AvailableStock { get; set; }

        [Timestamp]
        public Byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for related rentals
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
