namespace Entities.DTOs.FriendsList;

public class FriendsListResponseDto
{
    public Guid Id {get; set;}
    public Guid ProfileId {get; set;}
    public Guid FriendId {get; set;}
    public DateTime CreatedAt {get; set;}
}
