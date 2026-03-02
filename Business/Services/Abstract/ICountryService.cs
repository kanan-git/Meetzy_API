using Entities.DTOs.Country;

namespace Business.Services.Abstract;

public interface ICountryService
{
    public Task<List<CountryResponseDto>> GetAllCountries();
    public Task<CountryResponseDto> GetCountryById(Guid id);
    public Task<CountryResponseDto> GetCountryByName(string name);
    public Task CreateCountry(CountryCreateDto create);
    public Task UpdateCountry(Guid id, CountryUpdateDto update);
    public Task RemoveCountry(Guid id);
}
