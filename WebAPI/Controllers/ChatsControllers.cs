using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Chat;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ChatsControllers : ControllerBase
{
    private readonly IChatService _chatService;
    public ChatsControllers(IChatService chatService)
    {
        _chatService = chatService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllChats()
    {
        var result = await _chatService.GetAllChats();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetChatById(Guid id)
    {
        var result = await _chatService.GetChatById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateChat(ChatCreateDto create)
    {
        await _chatService.CreateChat(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateChat(Guid id, ChatUpdateDto update)
    {
        await _chatService.UpdateChat(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveChat(Guid id)
    {
        await _chatService.RemoveChat(id);
        return Ok();
    }
}
