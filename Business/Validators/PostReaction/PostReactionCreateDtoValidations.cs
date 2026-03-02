using FluentValidation;

using Entities.DTOs.PostReaction;

namespace Business.Validators.PostReaction;

public class PostReactionCreateDtoValidations:AbstractValidator<PostReactionCreateDto>
{
    public PostReactionCreateDtoValidations()
    {
        // RuleFor(pr => pr.ReactionType)
        //     .NotNull().WithMessage("This field is required!");
    }
}
