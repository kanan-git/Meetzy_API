using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.City;

namespace Business.Profiles;

public class CityProfiles:AutoMapper.Profile
{
    public CityProfiles()
    {
        CreateMap<CityCreateDto,City>();
        CreateMap<City,CityResponseDto>();
        CreateMap<CityUpdateDto,City>();
    }
}
