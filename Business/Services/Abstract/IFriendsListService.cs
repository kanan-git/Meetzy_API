using Entities.DTOs.FriendsList;

namespace Business.Services.Abstract;

public interface IFriendsListService
{
    public Task<List<FriendsListResponseDto>> GetAllFriendsLists();
    public Task<FriendsListResponseDto> GetFriendsListById(Guid id);
    public Task CreateFriendsList(FriendsListCreateDto create);
    public Task UpdateFriendsList(Guid id, FriendsListUpdateDto update);
    public Task RemoveFriendsList(Guid id);
}
