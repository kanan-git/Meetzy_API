using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.FriendRequest;

namespace Business.Profiles;

public class FriendRequestProfiles:AutoMapper.Profile
{
    public FriendRequestProfiles()
    {
        CreateMap<FriendRequestCreateDto,FriendRequest>();
        CreateMap<FriendRequest,FriendRequestResponseDto>();
        CreateMap<FriendRequestUpdateDto,FriendRequest>();
    }
}
