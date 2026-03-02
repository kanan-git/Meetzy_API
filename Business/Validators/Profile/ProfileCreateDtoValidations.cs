using FluentValidation;

using Entities.DTOs.Profile;

namespace Business.Validators.Profile;

public class ProfileCreateDtoValidations:AbstractValidator<ProfileCreateDto>
{
    public ProfileCreateDtoValidations()
    {
        // RuleFor(x => x.Addressline)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(40).WithMessage("This field requires less than or equal to 40 symbols!");
        // RuleFor(x => x.IpV4Address)
        //     .MaximumLength(15).WithMessage("This field requires less than or equal to 15 symbols!");
        // RuleFor(x => x.IpV6Address)
        //     .MaximumLength(39).WithMessage("This field requires less than or equal to 39 symbols!");
        // RuleFor(x => x.IsPrivate)
        //     .NotNull().WithMessage("This field is required!");
    }
}
