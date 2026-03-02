using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.FriendsList;

namespace Business.Profiles;

public class FriendsListProfiles:AutoMapper.Profile
{
    public FriendsListProfiles()
    {
        CreateMap<FriendsListCreateDto,FriendsList>();
        CreateMap<FriendsList,FriendsListResponseDto>();
        CreateMap<FriendsListUpdateDto,FriendsList>();
    }
}
