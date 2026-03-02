using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.ActivityLog;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ActivityLogsControllers : ControllerBase
{
    private readonly IActivityLogService _activityService;
    public ActivityLogsControllers(IActivityLogService activityLogService)
    {
        _activityService = activityLogService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllActivities()
    {
        var result = await _activityService.GetAllActivities();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetActivityLogById(Guid id)
    {
        var result = await _activityService.GetActivityLogById(id);
        return Ok(result);
    }

    [HttpGet("{actionName}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetActivityLogByActionName(string actionName)
    {
        var result = await _activityService.GetActivityLogByActionName(actionName);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateActivity(ActivityLogCreateDto create)
    {
        // await _activityService.CreateActivity(create);
        // return Ok();
        try
        {
            await _activityService.CreateActivity(create);
        }
        catch(Exception exception)
        {
            return BadRequest(new {Errors=exception});
        }
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> UpdateActivity(Guid id, ActivityLogUpdateDto update)
    {
        await _activityService.UpdateActivity(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin")]
    public async Task<IActionResult> RemoveActivity(Guid id)
    {
        await _activityService.RemoveActivity(id);
        return Ok();
    }
}
