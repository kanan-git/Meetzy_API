namespace Entities.DTOs.Message;

public class MessageResponseDto
{
    public Guid Id {get; set;}
    public string TextContent {get; set;}
    public bool IsRead {get; set;}
    public Guid ChatId {get; set;}
    public Guid SenderProfileId {get; set;}
    public Guid ReceiverProfileId {get; set;}
    public DateTime CreatedAt {get; set;}
}
