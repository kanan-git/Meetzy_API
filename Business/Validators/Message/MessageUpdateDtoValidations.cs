using FluentValidation;

using Entities.DTOs.Message;

namespace Business.Validators.Message;

public class MessageUpdateDtoValidations:AbstractValidator<MessageUpdateDto>
{
    public MessageUpdateDtoValidations()
    {
    }
}
