using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.MediaFile;

namespace Business.Services.Concrete;

public class MediaFileService : IMediaFileService
{
    private readonly IMediaFileRepository _mediaFileRepo;
    private readonly IMapper _mapper;
    public MediaFileService(IMediaFileRepository mediaFileRepo, IMapper mapper)
    {
        _mediaFileRepo = mediaFileRepo;
        _mapper = mapper;
    }

    
    public async Task<List<MediaFileResponseDto>> GetAllMediaFiles()
    {
        return _mapper.Map<List<MediaFileResponseDto>>(await _mediaFileRepo.GetAllAsync());
    }

    public async Task<MediaFileResponseDto> GetMediaFileById(Guid id)
    {
        var result = await _mediaFileRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<MediaFileResponseDto>(result);
    }

    public async Task<MediaFileResponseDto> GetMediaFileByFileName(string fileName)
    {
        var result = await _mediaFileRepo.GetAsync(ex => ex.FileName == fileName);
        return _mapper.Map<MediaFileResponseDto>(result);
    }

    public async Task CreateMediaFile(MediaFileCreateDto create)
    {
        if(await _mediaFileRepo.IsExistEntity(ex => ex.FileName==create.FileName))
        {
            throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        }
        await _mediaFileRepo.AddAsync(_mapper.Map<MediaFile>(create));
        var result = await _mediaFileRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task<MediaFileResponseDto> CreateMediaFileWithResponse(MediaFileCreateDto create)
    {
        if(await _mediaFileRepo.IsExistEntity(ex => ex.FileName==create.FileName))
        {
            throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        }
        var data = _mapper.Map<MediaFile>(create);
        await _mediaFileRepo.AddAsync(data);
        var result = await _mediaFileRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
        var response = _mapper.Map<MediaFileResponseDto>(data);
        return response;
    }

    public async Task UpdateMediaFile(Guid id, MediaFileUpdateDto update)
    {
        var result = await _mediaFileRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _mediaFileRepo.SaveAsync();
    }

    public async Task RemoveMediaFile(Guid id)
    {
        var data = await _mediaFileRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mediaFileRepo.Remove(data);
        await _mediaFileRepo.SaveAsync();
    }
}
