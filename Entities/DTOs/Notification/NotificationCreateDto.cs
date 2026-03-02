namespace Entities.DTOs.Notification;

public class NotificationCreateDto
{
    public string Info {get; set;}
    public bool IsRead {get; set;}
    public Guid TargetProfileId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
