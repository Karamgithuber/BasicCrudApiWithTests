using FluentValidation;
using BasicCrudApiWithTests.Models;

namespace BasicCrudApiWithTests.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(20).WithMessage("UserName cannot exceed 20 characters.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email.");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");

            RuleFor(u => u.Address).NotEmpty();
            RuleFor(u => u.DateOfBirth).LessThan(DateTime.Now).WithMessage("DOB must be in the past.");
        }
    }

}
