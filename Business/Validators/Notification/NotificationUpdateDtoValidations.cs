using FluentValidation;

using Entities.DTOs.Notification;

namespace Business.Validators.Notification;

public class NotificationUpdateDtoValidations:AbstractValidator<NotificationUpdateDto>
{
    public NotificationUpdateDtoValidations()
    {
        // RuleFor(n => n.Info)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(40).WithMessage("This field requires less than or equal to 40 symbols!");
    }
}
