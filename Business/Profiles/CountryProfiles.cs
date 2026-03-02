using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Country;

namespace Business.Profiles;

public class CountryProfiles:AutoMapper.Profile
{
    public CountryProfiles()
    {
        CreateMap<CountryCreateDto,Country>();
        CreateMap<Country,CountryResponseDto>();
        CreateMap<CountryUpdateDto,Country>();
    }
}
