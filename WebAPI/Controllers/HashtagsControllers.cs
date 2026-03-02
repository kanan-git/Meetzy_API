using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Hashtag;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HashtagsControllers : ControllerBase
{
    private readonly IHashtagService _hashtagService;
    public HashtagsControllers(IHashtagService hashtagService)
    {
        _hashtagService = hashtagService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllHashtags()
    {
        var result = await _hashtagService.GetAllHashtags();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetHashtagById(Guid id)
    {
        var result = await _hashtagService.GetHashtagById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateHashtag(HashtagCreateDto create)
    {
        await _hashtagService.CreateHashtag(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateHashtag(Guid id, HashtagUpdateDto update)
    {
        await _hashtagService.UpdateHashtag(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveHashtag(Guid id)
    {
        await _hashtagService.RemoveHashtag(id);
        return Ok();
    }
}
