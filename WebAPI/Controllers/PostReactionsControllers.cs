using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.PostReaction;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PostReactionsControllers : ControllerBase
{
    private readonly IPostReactionService _postReactionsService;
    public PostReactionsControllers(IPostReactionService postReactionsService)
    {
        _postReactionsService = postReactionsService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllPostReactions()
    {
        var result = await _postReactionsService.GetAllPostReactions();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetPostReactionById(Guid id)
    {
        var result = await _postReactionsService.GetPostReactionById(id);
        return Ok(result);
    }

    [HttpGet("{reactionType}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetPostReactionByReactionType(string reactionType)
    {
        var result = await _postReactionsService.GetPostReactionByReactionType(reactionType);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreatePostReaction(PostReactionCreateDto create)
    {
        await _postReactionsService.CreatePostReaction(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdatePostReaction(Guid id, PostReactionUpdateDto update)
    {
        await _postReactionsService.UpdatePostReaction(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemovePostReaction(Guid id)
    {
        await _postReactionsService.RemovePostReaction(id);
        return Ok();
    }
}
