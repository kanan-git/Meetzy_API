using Entities.DTOs.Profile;

namespace Business.Services.Abstract;

public interface IProfileService
{
    public Task<List<ProfileResponseDto>> GetAllProfiles();
    public Task<ProfileResponseDto> GetProfileById(Guid id);
    public Task CreateProfile(ProfileCreateDto create);
    public Task UpdateProfile(Guid id, ProfileUpdateDto update);
    public Task RemoveProfile(Guid id);
    public Task SetProfileImageAsync(Guid profileId, Guid mediaFileId);
}
