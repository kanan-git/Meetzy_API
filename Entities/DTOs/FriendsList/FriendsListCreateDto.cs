namespace Entities.DTOs.FriendsList;

public class FriendsListCreateDto
{
    public Guid ProfileId {get; set;}
    public Guid FriendId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
