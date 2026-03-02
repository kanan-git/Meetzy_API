using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.FriendRequest;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FriendRequestsControllers : ControllerBase
{
    private readonly IFriendRequestService _friendRequestService;
    public FriendRequestsControllers(IFriendRequestService friendRequestService)
    {
        _friendRequestService = friendRequestService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllFriendRequests()
    {
        var result = await _friendRequestService.GetAllFriendRequests();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetFriendRequestById(Guid id)
    {
        var result = await _friendRequestService.GetFriendRequestById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateFriendRequest(FriendRequestCreateDto create)
    {
        await _friendRequestService.CreateFriendRequest(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateFriendRequest(Guid id, FriendRequestUpdateDto update)
    {
        await _friendRequestService.UpdateFriendRequest(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveFriendRequest(Guid id)
    {
        await _friendRequestService.RemoveFriendRequest(id);
        return Ok();
    }
}
