using FluentValidation;

using Entities.DTOs.Auth;

namespace Business.Validators.Auth;

public class RegisterDtoValidations:AbstractValidator<RegisterDto>
{
    public RegisterDtoValidations()
    {
        // RuleFor(r => r.FirstName)
        //     .MinimumLength(1).WithMessage(MinSymbolErrorMessage(1))
        //     .MaximumLength(40).WithMessage(MaxSymbolErrorMessage(40));
        // RuleFor(r => r.LastName)
        //     .MinimumLength(1).WithMessage(MinSymbolErrorMessage(1))
        //     .MaximumLength(100).WithMessage(MaxSymbolErrorMessage(100));
        // RuleFor(r => r.UserName)
        //     .MinimumLength(5).WithMessage(MinSymbolErrorMessage(5))
        //     .MaximumLength(16).WithMessage(MaxSymbolErrorMessage(16));
        // RuleFor(r => r.Email)
        //     .MinimumLength(5).WithMessage(MinSymbolErrorMessage(5))
        //     .MaximumLength(40).WithMessage(MaxSymbolErrorMessage(40));
        // RuleFor(r => r.Password)
        //     .MinimumLength(8).WithMessage(MinSymbolErrorMessage(8))
        //     .MaximumLength(30).WithMessage(MaxSymbolErrorMessage(30));
    }

    public string MinSymbolErrorMessage(int SymbolCount)
    {
        string MessageText = $"This field requires greater than or equal to {SymbolCount} symbols!";
        return MessageText;
    }
    public string MaxSymbolErrorMessage(int SymbolCount)
    {
        string MessageText = $"This field requires less than or equal to {SymbolCount} symbols!";
        return MessageText;
    }
}
