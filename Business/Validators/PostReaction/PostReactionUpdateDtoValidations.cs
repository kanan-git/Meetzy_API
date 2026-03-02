using FluentValidation;

using Entities.DTOs.PostReaction;

namespace Business.Validators.PostReaction;

public class PostReactionUpdateDtoValidations:AbstractValidator<PostReactionUpdateDto>
{
    public PostReactionUpdateDtoValidations()
    {
        // RuleFor(pr => pr.ReactionType)
        //     .NotNull().WithMessage("This field is required!");
    }
}
