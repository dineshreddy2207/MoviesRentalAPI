using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public class MovieValidator
    {
        public class MovieCreateValidator : AbstractValidator<MovieCreateDto>
        {
            public MovieCreateValidator()
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
                RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters");
                RuleFor(x => x.ReleaseYear).NotEmpty().WithMessage("Release year is required").InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Release year must be between 1900 and {DateTime.Now.Year}");
                RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre is required").Length(3, 50).WithMessage("Genre must be between 3 and 50 characters");
                RuleFor(x => x.DurationInMinutes).NotEmpty().WithMessage("Duration is required").GreaterThan(0).WithMessage("Duration must be greater than 0").LessThanOrEqualTo(600).WithMessage("Duration must be 600 minutes or less");
                RuleFor(x => x.RentalPrice).NotEmpty().WithMessage("Rental price is required").GreaterThan(0).WithMessage("Rental price must be greater than 0").LessThanOrEqualTo(100).WithMessage("Rental price must not exceed 100");
                RuleFor(x => x.AvailableStock).NotEmpty().WithMessage("Stock is required").GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative").LessThanOrEqualTo(10000).WithMessage("Stock must not exceed 10000");

            }

            public class MovieUpdateValidator : AbstractValidator<MovieUpdateDto>
            {
                public MovieUpdateValidator()
                {
                    RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie ID is required").GreaterThan(0).WithMessage("Movie ID must be greater than 0");
                    RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").Length(3, 200).WithMessage("Title must be between 3 and 200 characters");
                    RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required").Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters");
                    RuleFor(x => x.ReleaseYear).NotEmpty().WithMessage("Release year is required").InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Release year must be between 1900 and {DateTime.Now.Year}");
                    RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre is required").Length(3, 50).WithMessage("Genre must be between 3 and 50 characters");
                    RuleFor(x => x.DurationInMinutes).NotEmpty().WithMessage("Duration is required").GreaterThan(0).WithMessage("Duration must be greater than 0").LessThanOrEqualTo(600).WithMessage("Duration must be 600 minutes or less");
                    RuleFor(x => x.RentalPrice).NotEmpty().WithMessage("Rental price is required").GreaterThan(0).WithMessage("Rental price must be greater than 0").LessThanOrEqualTo(100).WithMessage("Rental price must not exceed 100");
                    RuleFor(x => x.AvailableStock).NotEmpty().WithMessage("Stock is required").GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative").LessThanOrEqualTo(10000).WithMessage("Stock must not exceed 10000");

                }
            }
        }
    }
}
