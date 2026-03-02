using FluentValidation;

using Entities.DTOs.Country;

namespace Business.Validators.Country;

public class CountryCreateDtoValidations:AbstractValidator<CountryCreateDto>
{
    public CountryCreateDtoValidations()
    {
        // RuleFor(c => c.Name)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(30).WithMessage("This field requires less than or equal to 30 symbols!");
        // RuleFor(c => c.IsoCode)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(30).WithMessage("This field requires less than or equal to 30 symbols!");
    }
}
