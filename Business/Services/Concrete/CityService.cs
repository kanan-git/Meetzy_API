using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.City;

namespace Business.Services.Concrete;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepo;
    private readonly IMapper _mapper;
    public CityService(ICityRepository cityRepo, IMapper mapper)
    {
        _cityRepo = cityRepo;
        _mapper = mapper;
    }

    
    public async Task<List<CityResponseDto>> GetAllCities()
    {
        return _mapper.Map<List<CityResponseDto>>(await _cityRepo.GetAllAsync());
    }

    public async Task<CityResponseDto> GetCityById(Guid id)
    {
        var result = await _cityRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<CityResponseDto>(result);
    }

    public async Task<CityResponseDto> GetCityByName(string name)
    {
        var result = await _cityRepo.GetAsync(ex => ex.Name == name);
        return _mapper.Map<CityResponseDto>(result);
    }

    public async Task CreateCity(CityCreateDto create)
    {
        if(await _cityRepo.IsExistEntity(ex => ex.Name==create.Name))
        {
            throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        }
        await _cityRepo.AddAsync(_mapper.Map<City>(create));
        var result = await _cityRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateCity(Guid id, CityUpdateDto update)
    {
        var result = await _cityRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _cityRepo.SaveAsync();
    }

    public async Task RemoveCity(Guid id)
    {
        var data = await _cityRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _cityRepo.Remove(data);
        await _cityRepo.SaveAsync();
    }
}
