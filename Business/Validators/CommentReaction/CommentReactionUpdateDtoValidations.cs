using FluentValidation;

using Entities.DTOs.CommentReaction;

namespace Business.Validators.CommentReaction;

public class CommentReactionUpdateDtoValidations:AbstractValidator<CommentReactionUpdateDto>
{
    public CommentReactionUpdateDtoValidations()
    {
        // RuleFor(cr => cr.ReactionType)
        //     .NotNull().WithMessage("This field is required!");
    }
}
