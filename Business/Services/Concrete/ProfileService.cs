using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Profile;

namespace Business.Services.Concrete;

public class ProfileService : IProfileService
{
    // private readonly IMediaService _mediaService;
    private readonly IMediaFileRepository _mediaFileRepo;
    private readonly IProfileRepository _profileRepo;
    private readonly IMapper _mapper;
    public ProfileService(IMediaFileRepository mediaFileRepo, IProfileRepository profileRepo, IMapper mapper)
    {
        // _mediaService = mediaService;
        _mediaFileRepo = mediaFileRepo;
        _profileRepo = profileRepo;
        _mapper = mapper;
    }

    
    public async Task<List<ProfileResponseDto>> GetAllProfiles()
    {
        return _mapper.Map<List<ProfileResponseDto>>(await _profileRepo.GetAllAsync());
    }

    public async Task<ProfileResponseDto> GetProfileById(Guid id)
    {
        var result = await _profileRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<ProfileResponseDto>(result);
    }

    public async Task CreateProfile(ProfileCreateDto create)
    {
        await _profileRepo.AddAsync(_mapper.Map<Entities.Concrete.Profile>(create));
        var result = await _profileRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateProfile(Guid id, ProfileUpdateDto update)
    {
        var result = await _profileRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        // if (update.ProfilePictureUrl != null)
        // {
        //     var imagePath = await _mediaService.UploadProfileImageAsync(update.ProfilePictureUrl);
        //     result.ProfilePictureUrl = imagePath;
        // }
        _mapper.Map(update, result);
        await _profileRepo.SaveAsync();
    }

    public async Task RemoveProfile(Guid id)
    {
        var data = await _profileRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _profileRepo.Remove(data);
        await _profileRepo.SaveAsync();
    }

    public async Task SetProfileImageAsync(Guid profileId, Guid mediaFileId)
    {
        var profile = await _profileRepo.GetAsync(p => p.Id == profileId);
        if(profile == null)
        {
            throw new Exception(ExceptionMessages.NotFound);
        }
        profile.ProfileImageId = mediaFileId;
        await _profileRepo.SaveAsync();
    }
}
