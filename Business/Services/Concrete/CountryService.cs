using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Country;

namespace Business.Services.Concrete;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepo;
    private readonly IMapper _mapper;
    public CountryService(ICountryRepository countryRepo, IMapper mapper)
    {
        _countryRepo = countryRepo;
        _mapper = mapper;
    }

    
    public async Task<List<CountryResponseDto>> GetAllCountries()
    {
        return _mapper.Map<List<CountryResponseDto>>(await _countryRepo.GetAllAsync());
    }

    public async Task<CountryResponseDto> GetCountryById(Guid id)
    {
        var result = await _countryRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<CountryResponseDto>(result);
    }

    public async Task<CountryResponseDto> GetCountryByName(string name)
    {
        var result = await _countryRepo.GetAsync(ex => ex.Name == name);
        return _mapper.Map<CountryResponseDto>(result);
    }

    public async Task CreateCountry(CountryCreateDto create)
    {
        if(await _countryRepo.IsExistEntity(ex => ex.Name==create.Name))
        {
            throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        }
        await _countryRepo.AddAsync(_mapper.Map<Country>(create));
        var result = await _countryRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateCountry(Guid id, CountryUpdateDto update)
    {
        var result = await _countryRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _countryRepo.SaveAsync();
    }

    public async Task RemoveCountry(Guid id)
    {
        var data = await _countryRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _countryRepo.Remove(data);
        await _countryRepo.SaveAsync();
    }
}
