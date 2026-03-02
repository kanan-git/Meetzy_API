using FluentValidation;

using Entities.DTOs.Auth;

namespace Business.Validators.Auth;

public class LoginDtoValidations:AbstractValidator<LoginDto>
{
    public LoginDtoValidations()
    {
        // RuleFor(l => l.UserName)
        //     .MinimumLength(5).WithMessage("This field requires greater than or equal to 5 symbols!")
        //     .MaximumLength(16).WithMessage("This field requires less than or equal to 16 symbols!");
        // RuleFor(l => l.Password)
        //     .MinimumLength(8).WithMessage("This field requires greater than or equal to 8 symbols!")
        //     .MaximumLength(30).WithMessage("This field requires less than or equal to 30 symbols!");
    }
}
