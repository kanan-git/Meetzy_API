namespace Entities.DTOs.FriendRequest;

public class FriendRequestResponseDto
{
    public Guid Id {get; set;}
    public string Status {get; set;}
    public Guid SenderProfileId {get; set;}
    public Guid ReceiverProfileId {get; set;}
    public DateTime CreatedAt {get; set;}
}
