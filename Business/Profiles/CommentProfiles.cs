using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Comment;

namespace Business.Profiles;

public class CommentProfiles:AutoMapper.Profile
{
    public CommentProfiles()
    {
        CreateMap<CommentCreateDto,Comment>();
        CreateMap<Comment,CommentResponseDto>();
        CreateMap<CommentUpdateDto,Comment>();
    }
}
