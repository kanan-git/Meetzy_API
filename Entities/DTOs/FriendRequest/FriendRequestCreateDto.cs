namespace Entities.DTOs.FriendRequest;

public class FriendRequestCreateDto
{
    public string Status {get; set;}
    public Guid SenderProfileId {get; set;}
    public Guid ReceiverProfileId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
