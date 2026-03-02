namespace Entities.DTOs.Chat;

public class ChatUpdateDto
{
    public Guid ProfileNo1Id {get; set;}
    public Guid ProfileNo2Id {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
