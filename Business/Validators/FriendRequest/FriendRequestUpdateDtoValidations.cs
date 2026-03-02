using FluentValidation;

using Entities.DTOs.FriendRequest;

namespace Business.Validators.FriendRequest;

public class FriendRequestUpdateDtoValidations:AbstractValidator<FriendRequestUpdateDto>
{
    public FriendRequestUpdateDtoValidations()
    {
        // RuleFor(fr => fr.Status)
        //     .NotNull().WithMessage("This field is required!");
    }
}
