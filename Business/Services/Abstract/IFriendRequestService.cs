using Entities.DTOs.FriendRequest;

namespace Business.Services.Abstract;

public interface IFriendRequestService
{
    public Task<List<FriendRequestResponseDto>> GetAllFriendRequests();
    public Task<FriendRequestResponseDto> GetFriendRequestById(Guid id);
    public Task CreateFriendRequest(FriendRequestCreateDto create);
    public Task UpdateFriendRequest(Guid id, FriendRequestUpdateDto update);
    public Task RemoveFriendRequest(Guid id);
}
