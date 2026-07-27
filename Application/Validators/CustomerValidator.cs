using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public class CustomerCreateValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required").Length(2, 100).WithMessage("First name must be between 2 and 100 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required").Length(2, 100).WithMessage("Last name must be between 2 and 100 characters");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required").Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required").Length(5, 500).WithMessage("Address must be between 5 and 500 characters");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required").Length(2, 100).WithMessage("City must be between 2 and 100 characters");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required").Length(1, 20).WithMessage("Postal code must be between 1 and 20 characters");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required").Length(2, 100).WithMessage("Country must be between 2 and 100 characters");
            RuleFor(x => x.MembershipFee).GreaterThanOrEqualTo(0m).WithMessage("Membership fee cannot be negative").LessThanOrEqualTo(999999.99m).WithMessage("Membership fee must not exceed 999999.99");

        }
    }

    public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required").GreaterThan(0).WithMessage("Customer ID must be greater than 0");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required").Length(2, 100).WithMessage("First name must be between 2 and 100 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required").Length(2, 100).WithMessage("Last name must be between 2 and 100 characters");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address format");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required").Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required").Length(5, 500).WithMessage("Address must be between 5 and 500 characters");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required").Length(2, 100).WithMessage("City must be between 2 and 100 characters");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Postal code is required").Length(1, 20).WithMessage("Postal code must be between 1 and 20 characters");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required").Length(2, 100).WithMessage("Country must be between 2 and 100 characters");
            RuleFor(x => x.MembershipFee).GreaterThanOrEqualTo(0m).WithMessage("Membership fee cannot be negative").LessThanOrEqualTo(999999.99m).WithMessage("Membership fee must not exceed 999999.99");

        }
    }
}
