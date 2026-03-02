using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Message;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MessagesControllers : ControllerBase
{
    private readonly IMessageService _messageService;
    public MessagesControllers(IMessageService messageService)
    {
        _messageService = messageService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllMessages()
    {
        var result = await _messageService.GetAllMessages();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetMessageById(Guid id)
    {
        var result = await _messageService.GetMessageById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateMessage(MessageCreateDto create)
    {
        await _messageService.CreateMessage(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateMessage(Guid id, MessageUpdateDto update)
    {
        await _messageService.UpdateMessage(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveMessage(Guid id)
    {
        await _messageService.RemoveMessage(id);
        return Ok();
    }
}
