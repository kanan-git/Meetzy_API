using Entities.DTOs.MediaFile;

namespace Business.Services.Abstract;

public interface IMediaFileService
{
    public Task<List<MediaFileResponseDto>> GetAllMediaFiles();
    public Task<MediaFileResponseDto> GetMediaFileById(Guid id);
    public Task<MediaFileResponseDto> GetMediaFileByFileName(string fileName);
    public Task CreateMediaFile(MediaFileCreateDto create);
    public Task UpdateMediaFile(Guid id, MediaFileUpdateDto update);
    public Task RemoveMediaFile(Guid id);
    public Task<MediaFileResponseDto> CreateMediaFileWithResponse(MediaFileCreateDto create);
}
