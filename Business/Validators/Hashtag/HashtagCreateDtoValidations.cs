using FluentValidation;

using Entities.DTOs.Hashtag;

namespace Business.Validators.Hashtag;

public class HashtagCreateDtoValidations:AbstractValidator<HashtagCreateDto>
{
    public HashtagCreateDtoValidations()
    {
        // RuleFor(h => h.TagValue)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(16).WithMessage("This field requires less than or equal to 16 symbols!");
    }
}
