using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Chat;

namespace Business.Profiles;

public class ChatProfiles:AutoMapper.Profile
{
    public ChatProfiles()
    {
        CreateMap<ChatCreateDto,Chat>();
        CreateMap<Chat,ChatResponseDto>();
        CreateMap<ChatUpdateDto,Chat>();
    }
}
