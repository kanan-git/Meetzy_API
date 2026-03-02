using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

using Business.Services.Abstract;
using Entities.DTOs.MediaFile;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MediaFilesControllers : ControllerBase
{
    private readonly IMediaFileService _mediaFileService;
    public MediaFilesControllers(IMediaFileService mediaFileService)
    {
        _mediaFileService = mediaFileService;
    }


    [HttpGet]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetAllMediaFiles()
    {
        var result = await _mediaFileService.GetAllMediaFiles();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetMediaFileById(Guid id)
    {
        var result = await _mediaFileService.GetMediaFileById(id);
        return Ok(result);
    }

    [HttpGet("{fileName}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> GetMediaFileByFileName(string fileName)
    {
        var result = await _mediaFileService.GetMediaFileByFileName(fileName);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> CreateMediaFile([FromForm] MediaFileCreateDto create, IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
            return BadRequest("File is empty");

        byte[] bytes;

        using (var ms = new MemoryStream())
        {
            await imageFile.CopyToAsync(ms);
            bytes = ms.ToArray();
        }

        create.FileData = bytes;
        create.FileName = imageFile.FileName;
        create.FileType = imageFile.ContentType;

        await _mediaFileService.CreateMediaFile(create);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> UpdateMediaFile(Guid id, MediaFileUpdateDto update)
    {
        await _mediaFileService.UpdateMediaFile(id, update);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles="Admin,User")]
    public async Task<IActionResult> RemoveMediaFile(Guid id)
    {
        await _mediaFileService.RemoveMediaFile(id);
        return Ok();
    }
}
