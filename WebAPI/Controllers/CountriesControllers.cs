using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Country;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CountriesControllers : ControllerBase
{
    private readonly ICountryService _countyService;
    public CountriesControllers(ICountryService countyService)
    {
        _countyService = countyService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllCountries()
    {
        var result = await _countyService.GetAllCountries();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCountryById(Guid id)
    {
        var result = await _countyService.GetCountryById(id);
        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCountryByName(string name)
    {
        var result = await _countyService.GetCountryByName(name);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> CreateCountry(CountryCreateDto create)
    {
        await _countyService.CreateCountry(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> UpdateCountry(Guid id, CountryUpdateDto update)
    {
        await _countyService.UpdateCountry(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> RemoveCountry(Guid id)
    {
        await _countyService.RemoveCountry(id);
        return Ok();
    }
}
