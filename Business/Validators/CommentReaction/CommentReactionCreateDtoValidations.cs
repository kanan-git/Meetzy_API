using FluentValidation;

using Entities.DTOs.CommentReaction;

namespace Business.Validators.CommentReaction;

public class CommentReactionCreateDtoValidations:AbstractValidator<CommentReactionCreateDto>
{
    public CommentReactionCreateDtoValidations()
    {
        // RuleFor(cr => cr.ReactionType)
        //     .NotNull().WithMessage("This field is required!");
    }
}
