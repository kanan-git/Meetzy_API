using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.City;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CitiesControllers : ControllerBase
{
    private readonly ICityService _cityService;
    public CitiesControllers(ICityService cityService)
    {
        _cityService = cityService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllCities()
    {
        var result = await _cityService.GetAllCities();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCityById(Guid id)
    {
        var result = await _cityService.GetCityById(id);
        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCityByName(string name)
    {
        var result = await _cityService.GetCityByName(name);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> CreateCity(CityCreateDto create)
    {
        await _cityService.CreateCity(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> UpdateCity(Guid id, CityUpdateDto update)
    {
        await _cityService.UpdateCity(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> RemoveCity(Guid id)
    {
        await _cityService.RemoveCity(id);
        return Ok();
    }
}
