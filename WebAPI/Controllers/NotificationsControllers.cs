using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Notification;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class NotificationsControllers : ControllerBase
{
    private readonly INotificationService _notificationService;
    public NotificationsControllers(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllNotifications()
    {
        var result = await _notificationService.GetAllNotifications();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetNotificationById(Guid id)
    {
        var result = await _notificationService.GetNotificationById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateNotification(NotificationCreateDto create)
    {
        await _notificationService.CreateNotification(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateNotification(Guid id, NotificationUpdateDto update)
    {
        await _notificationService.UpdateNotification(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveNotification(Guid id)
    {
        await _notificationService.RemoveNotification(id);
        return Ok();
    }
}
