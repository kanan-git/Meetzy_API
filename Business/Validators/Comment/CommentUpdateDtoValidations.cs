using FluentValidation;

using Entities.DTOs.Comment;

namespace Business.Validators.Comment;

public class CommentUpdateDtoValidations:AbstractValidator<CommentUpdateDto>
{
    public CommentUpdateDtoValidations()
    {
    }
}
