namespace Entities.DTOs.Chat;

public class ChatCreateDto
{
    public Guid ProfileNo1Id {get; set;}
    public Guid ProfileNo2Id {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
