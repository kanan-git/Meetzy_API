using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.FriendsList;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FriendsListsControllers : ControllerBase
{
    private readonly IFriendsListService _friendsListService;
    public FriendsListsControllers(IFriendsListService friendsListService)
    {
        _friendsListService = friendsListService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllFriendsLists()
    {
        var result = await _friendsListService.GetAllFriendsLists();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetFriendsListById(Guid id)
    {
        var result = await _friendsListService.GetFriendsListById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateFriendsList(FriendsListCreateDto create)
    {
        await _friendsListService.CreateFriendsList(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateFriendsList(Guid id, FriendsListUpdateDto update)
    {
        await _friendsListService.UpdateFriendsList(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveFriendsList(Guid id)
    {
        await _friendsListService.RemoveFriendsList(id);
        return Ok();
    }
}
