using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Comment;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CommentsControllers : ControllerBase
{
    private readonly ICommentService _commentService;
    public CommentsControllers(ICommentService commentService)
    {
        _commentService = commentService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllComments()
    {
        var result = await _commentService.GetAllComments();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var result = await _commentService.GetCommentById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateComment(CommentCreateDto create)
    {
        await _commentService.CreateComment(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateComment(Guid id, CommentUpdateDto update)
    {
        await _commentService.UpdateComment(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveComment(Guid id)
    {
        await _commentService.RemoveComment(id);
        return Ok();
    }
}
