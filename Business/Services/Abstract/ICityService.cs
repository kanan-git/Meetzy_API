using Entities.DTOs.City;

namespace Business.Services.Abstract;

public interface ICityService
{
    public Task<List<CityResponseDto>> GetAllCities();
    public Task<CityResponseDto> GetCityById(Guid id);
    public Task<CityResponseDto> GetCityByName(string name);
    public Task CreateCity(CityCreateDto create);
    public Task UpdateCity(Guid id, CityUpdateDto update);
    public Task RemoveCity(Guid id);
}
