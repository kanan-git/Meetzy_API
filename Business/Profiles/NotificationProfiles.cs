using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Notification;

namespace Business.Profiles;

public class NotificationProfiles:AutoMapper.Profile
{
    public NotificationProfiles()
    {
        CreateMap<NotificationCreateDto,Notification>();
        CreateMap<Notification,NotificationResponseDto>();
        CreateMap<NotificationUpdateDto,Notification>();
    }
}
