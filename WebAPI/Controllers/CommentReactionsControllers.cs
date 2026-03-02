using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.CommentReaction;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CommentReactionsControllers : ControllerBase
{
    private readonly ICommentReactionService _commentReactionService;
    public CommentReactionsControllers(ICommentReactionService commentReaction)
    {
        _commentReactionService = commentReaction;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllCommentReactions()
    {
        var result = await _commentReactionService.GetAllCommentReactions();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCommentReactionById(Guid id)
    {
        var result = await _commentReactionService.GetCommentReactionById(id);
        return Ok(result);
    }

    [HttpGet("{reactionType}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCommentReactionByReactionType(string reactionType)
    {
        var result = await _commentReactionService.GetCommentReactionByReactionType(reactionType);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateCommentReaction(CommentReactionCreateDto create)
    {
        await _commentReactionService.CreateCommentReaction(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateCommentReaction(Guid id, CommentReactionUpdateDto update)
    {
        await _commentReactionService.UpdateCommentReaction(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveCommentReaction(Guid id)
    {
        await _commentReactionService.RemoveCommentReaction(id);
        return Ok();
    }
}
