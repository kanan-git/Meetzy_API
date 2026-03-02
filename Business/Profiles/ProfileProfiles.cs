using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Profile;

namespace Business.Profiles;

public class ProfileProfiles:AutoMapper.Profile
{
    public ProfileProfiles()
    {
        CreateMap<ProfileCreateDto,Entities.Concrete.Profile>();
        CreateMap<Entities.Concrete.Profile,ProfileResponseDto>();
        CreateMap<ProfileUpdateDto,Entities.Concrete.Profile>();
    }
}
