using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.CommentReaction;

namespace Business.Profiles;

public class CommentReactionProfiles:AutoMapper.Profile
{
    public CommentReactionProfiles()
    {
        CreateMap<CommentReactionCreateDto,CommentReaction>();
        CreateMap<CommentReaction,CommentReactionResponseDto>();
        CreateMap<CommentReactionUpdateDto,CommentReaction>();
    }
}
