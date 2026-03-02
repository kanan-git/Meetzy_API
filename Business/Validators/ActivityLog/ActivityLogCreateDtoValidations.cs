using FluentValidation;

using Entities.DTOs.ActivityLog;

namespace Business.Validators.ActivityLog;

public class ActivityLogCreateDtoValidations:AbstractValidator<ActivityLogCreateDto>
{
    public ActivityLogCreateDtoValidations()
    {
        // RuleFor(al => al.Action)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(40).WithMessage("This field requires less than or equal to 40 symbols!"); // error messages from static constant later
        // RuleFor(al => al.Details)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(100).WithMessage("This field requires less than or equal to 100 symbols!");
        // RuleFor(al => al.IpV4Address)
        //     .MaximumLength(15).WithMessage("This field requires less than or equal to 15 symbols!");
        // RuleFor(al => al.IpV6Address)
        //     .MaximumLength(39).WithMessage("This field requires less than or equal to 39 symbols!");
    }
}
