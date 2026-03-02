namespace Entities.DTOs.FriendsList;

public class FriendsListUpdateDto
{
    public Guid ProfileId {get; set;}
    public Guid FriendId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
