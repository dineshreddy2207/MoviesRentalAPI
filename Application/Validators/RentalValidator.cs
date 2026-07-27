using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public class RentalCreateValidator : AbstractValidator<RentalCreateDto>
    {
        public RentalCreateValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required").GreaterThan(0).WithMessage("Customer ID must be greater than 0");
            RuleFor(x => x.MovieId).NotEmpty().WithMessage("Movie ID is required").GreaterThan(0).WithMessage("Movie ID must be greater than 0");
            RuleFor(x => x.DueDate).NotEmpty().WithMessage("Due date is required").GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future");
        }
    }

    public class RentalUpdateValidator : AbstractValidator<RentalUpdateDto>
    {
        public RentalUpdateValidator()
        {
            RuleFor(x => x.RentalId).NotEmpty().WithMessage("Rental ID is required").GreaterThan(0).WithMessage("Rental ID must be greater than 0");
            RuleFor(x => x.DueDate).NotEmpty().WithMessage("Due date is required").GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required").Must(s => new[] { "Active", "Returned", "Overdue" }.Contains(s)).WithMessage("Status must be 'Active', 'Returned', or 'Overdue'");
        }
    }
}
