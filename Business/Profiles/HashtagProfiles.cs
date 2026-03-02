using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Hashtag;

namespace Business.Profiles;

public class HashtagProfiles:AutoMapper.Profile
{
    public HashtagProfiles()
    {
        CreateMap<HashtagCreateDto,Hashtag>();
        CreateMap<Hashtag,HashtagResponseDto>();
        CreateMap<HashtagUpdateDto,Hashtag>();
    }
}
