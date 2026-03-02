using FluentValidation;

using Entities.DTOs.Post;

namespace Business.Validators.Post;

public class PostCreateDtoValidations:AbstractValidator<PostCreateDto>
{
    public PostCreateDtoValidations()
    {
        // RuleFor(p => p.Location)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(40).WithMessage("This field requires less than or equal to 40 symbols!");
    }
}
