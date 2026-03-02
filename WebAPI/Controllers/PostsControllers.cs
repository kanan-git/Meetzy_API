using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Post;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PostsControllers : ControllerBase
{
    private readonly IPostService _postService;
    public PostsControllers(IPostService postService)
    {
        _postService = postService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllPosts()
    {
        var result = await _postService.GetAllPosts();
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllPostsPaginated(int page, int size)
    {
        var result = await _postService.GetAllPostsPaginated(page, size);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetPostById(Guid id)
    {
        var result = await _postService.GetPostById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreatePost(PostCreateDto create)
    {
        await _postService.CreatePost(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdatePost(Guid id, PostUpdateDto update)
    {
        await _postService.UpdatePost(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemovePost(Guid id)
    {
        await _postService.RemovePost(id);
        return Ok();
    }
}
