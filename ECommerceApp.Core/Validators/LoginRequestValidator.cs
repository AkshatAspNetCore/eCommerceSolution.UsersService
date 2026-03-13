using ECommerceApp.Core.DTO;
using FluentValidation;
namespace ECommerceApp.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator() { 

    //Email
    RuleFor(e => e.Email).NotEmpty().WithMessage("Email is required.")
        .EmailAddress().WithMessage("Invalid email format.");

    //Password
    RuleFor(e => e.Password).NotEmpty().WithMessage("Password is required.");
    }
}

