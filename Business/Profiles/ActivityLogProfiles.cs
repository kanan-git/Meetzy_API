using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.ActivityLog;

namespace Business.Profiles;

public class ActivityLogProfiles:AutoMapper.Profile
{
    public ActivityLogProfiles()
    {
        CreateMap<ActivityLogCreateDto,ActivityLog>().ReverseMap();
        CreateMap<ActivityLog,ActivityLogResponseDto>().ForMember(al => al.Action, opt => opt.MapFrom(al => al.Action));
        CreateMap<ActivityLogUpdateDto,ActivityLog>();
    }
}
