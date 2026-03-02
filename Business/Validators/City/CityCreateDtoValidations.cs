using FluentValidation;

using Entities.DTOs.City;

namespace Business.Validators.City;

public class CityCreateDtoValidations:AbstractValidator<CityCreateDto>
{
    public CityCreateDtoValidations()
    {
    }
}
