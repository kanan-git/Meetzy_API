using FluentValidation;

using Entities.DTOs.Message;

namespace Business.Validators.Message;

public class MessageCreateDtoValidations:AbstractValidator<MessageCreateDto>
{
    public MessageCreateDtoValidations()
    {
    }
}
