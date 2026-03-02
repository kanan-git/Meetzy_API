using FluentValidation;

using Entities.DTOs.FriendRequest;

namespace Business.Validators.FriendRequest;

public class FriendRequestCreateDtoValidations:AbstractValidator<FriendRequestCreateDto>
{
    public FriendRequestCreateDtoValidations()
    {
        // RuleFor(fr => fr.Status)
        //     .NotNull().WithMessage("This field is required!");
    }
}
