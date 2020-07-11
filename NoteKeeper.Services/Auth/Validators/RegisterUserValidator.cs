using FluentValidation;
using NoteKeeper.Infrastructure.Dto.Auth;

namespace NoteKeeper.Services.Auth.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("The email can not be empty")
                .EmailAddress().WithMessage("You must enter a valid email address")
                .NotNull();

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("The username can not be empty")
                .NotNull();

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("The password can not be empty")
                .NotNull()
                .MinimumLength(6).WithMessage("The password length must be between 6 and 50 characters")
                .MaximumLength(50).WithMessage("The password length must be between 6 and 50 characters");
        }
    }
}