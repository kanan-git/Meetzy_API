using FluentValidation;

using Entities.DTOs.Hashtag;

namespace Business.Validators.Hashtag;

public class HashtagUpdateDtoValidations:AbstractValidator<HashtagUpdateDto>
{
    public HashtagUpdateDtoValidations()
    {
        // RuleFor(h => h.TagValue)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(16).WithMessage("This field requires less than or equal to 16 symbols!");
    }
}
