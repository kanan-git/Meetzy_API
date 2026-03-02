using AutoMapper;
using Entities.Auth;
using Entities.DTOs.Auth;

namespace Business.Profiles;

public class AuthProfiles:Profile
{
    public AuthProfiles()
    {
        CreateMap<AppUser,RegisterDto>().ReverseMap();

        CreateMap<AppUser,LoginDto>().ReverseMap();
    }
}
