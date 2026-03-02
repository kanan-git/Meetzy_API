namespace Entities.DTOs.Message;

public class MessageCreateDto
{
    public string TextContent {get; set;}
    public bool IsRead {get; set;}
    public Guid ChatId {get; set;}
    public Guid SenderProfileId {get; set;}
    public Guid ReceiverProfileId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
