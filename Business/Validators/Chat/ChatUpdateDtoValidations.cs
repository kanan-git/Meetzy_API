using FluentValidation;

using Entities.DTOs.Chat;

namespace Business.Validators.Chat;

public class ChatUpdateDtoValidations:AbstractValidator<ChatUpdateDto>
{
    public ChatUpdateDtoValidations()
    {
    }
}
