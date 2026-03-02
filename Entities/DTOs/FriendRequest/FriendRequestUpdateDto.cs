namespace Entities.DTOs.FriendRequest;

public class FriendRequestUpdateDto
{
    public string Status {get; set;}
    public Guid SenderProfileId {get; set;}
    public Guid ReceiverProfileId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
