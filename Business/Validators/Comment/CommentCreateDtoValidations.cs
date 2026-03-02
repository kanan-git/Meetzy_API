using FluentValidation;

using Entities.DTOs.Comment;

namespace Business.Validators.Comment;

public class CommentCreateDtoValidations:AbstractValidator<CommentCreateDto>
{
    public CommentCreateDtoValidations()
    {
    }
}
