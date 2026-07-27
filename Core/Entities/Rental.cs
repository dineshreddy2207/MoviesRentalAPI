using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{

    [Table("Rentals")]
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentalId { get; set; }

        [Required(ErrorMessage = "Customer ID is required")]
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Movie ID is required")]
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Rental date is required")]
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Rental price is required")]
        [Range(0.01, 1000, ErrorMessage = "Rental price must be between 0.01 and 1000")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal RentalPrice { get; set; }

        [Range(0, 10000, ErrorMessage = "Late fee must be valid")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal LateFee { get; set; } = 0;

        [Required(ErrorMessage = "Status is required")]
        [StringLength(20)]
        public string Status { get; set; } = "Active"; // Active, Returned, Overdue

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
