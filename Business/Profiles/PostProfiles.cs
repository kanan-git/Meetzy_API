using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Post;

namespace Business.Profiles;

public class PostProfiles:AutoMapper.Profile
{
    public PostProfiles()
    {
        CreateMap<PostCreateDto,Post>();
        CreateMap<Post,PostResponseDto>();
        CreateMap<PostUpdateDto,Post>();
    }
}
