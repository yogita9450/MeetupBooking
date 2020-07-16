using FluentValidation;
using DeveloperMeetupDomain.DTOs;
using DeveloperMeetup.Services.Interfaces;

namespace DeveloperMeetup.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator(IValidationService validationService)
        {
            RuleFor(n => n.FirstName)
                    .NotEmpty().WithMessage("FirstName is requried")
                    .MinimumLength(2)
                    .MaximumLength(60);

            RuleFor(n => n.LastName)
                    .NotEmpty().WithMessage("LastName is requried")
                    .MinimumLength(2)
                    .MaximumLength(60);

            RuleFor(n => n.Email)
                    .NotEmpty().WithMessage("Email is requried")
                    .EmailAddress().WithMessage("A valid email address is required");

            RuleFor(n => n.Password)
                    .NotEmpty().WithMessage("Password is requried")
                    .MinimumLength(8)
                    .Matches("[^a-zA-Z0-9]").WithMessage("Your password must be between 8 - 15 characters and must contain at least three of the following: upper case letter, lower case letter, number, symbol!")
                    .MaximumLength(15);

            RuleFor(n => n.Phone)
                    .NotEmpty().WithMessage("Phone is requried");

        }
    }
}
