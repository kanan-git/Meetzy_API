using FluentValidation;

using Entities.DTOs.Chat;

namespace Business.Validators.Chat;

public class ChatCreateDtoValidations:AbstractValidator<ChatCreateDto>
{
    public ChatCreateDtoValidations()
    {
    }
}
