using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Message;

namespace Business.Profiles;

public class MessageProfiles:AutoMapper.Profile
{
    public MessageProfiles()
    {
        CreateMap<MessageCreateDto,Message>();
        CreateMap<Message,MessageResponseDto>();
        CreateMap<MessageUpdateDto,Message>();
    }
}
