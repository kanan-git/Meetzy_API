using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.PostReaction;

namespace Business.Profiles;

public class PostReactionProfiles:AutoMapper.Profile
{
    public PostReactionProfiles()
    {
        CreateMap<PostReactionCreateDto,PostReaction>();
        CreateMap<PostReaction,PostReactionResponseDto>();
        CreateMap<PostReactionUpdateDto,PostReaction>();
    }
}
