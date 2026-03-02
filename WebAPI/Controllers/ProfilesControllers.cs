using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.Profile;
using Entities.DTOs.MediaFile;
using Entities.Concrete;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProfilesControllers : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediaFileService _mediaFileService;
    private readonly IProfileService _profileService;
    public ProfilesControllers(IMapper mapper, IMediaFileService mediaFileService, IProfileService profileService)
    {
        _mapper = mapper;
        _mediaFileService = mediaFileService;
        _profileService = profileService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllProfiles()
    {
        var result = await _profileService.GetAllProfiles();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetProfileById(Guid id)
    {
        var result = await _profileService.GetProfileById(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateProfile(ProfileCreateDto create)
    {
        await _profileService.CreateProfile(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    // public async Task<IActionResult> UpdateProfile(Guid id, ProfileUpdateDto update)
    public async Task<IActionResult> UpdateProfile([FromForm] Guid id, ProfileUpdateDto update)
    {
        await _profileService.UpdateProfile(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveProfile(Guid id)
    {
        await _profileService.RemoveProfile(id);
        return Ok();
    }

    [HttpPost("{Id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UploadProfileImage(Guid profileId, IFormFile profileImage)
    {
        if (profileImage == null || profileImage.Length == 0)
        return BadRequest("File is empty");

        byte[] bytes;

        using (var ms = new MemoryStream())
        {
            await profileImage.CopyToAsync(ms);
            bytes = ms.ToArray();
        }

        var mediaCreateDto = new MediaFileCreateDto
        {
            FileData = bytes,
            FileName = profileImage.FileName,
            FileType = profileImage.ContentType
        };

        var mediaResponse =
            await _mediaFileService.CreateMediaFileWithResponse(mediaCreateDto);

        await _profileService
            .SetProfileImageAsync(profileId, mediaResponse.Id);

        return Ok();
    }
}
