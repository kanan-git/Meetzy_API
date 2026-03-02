using FluentValidation;

using Entities.DTOs.City;

namespace Business.Validators.City;

public class CityUpdateDtoValidations:AbstractValidator<CityUpdateDto>
{
    public CityUpdateDtoValidations()
    {
    }
}
