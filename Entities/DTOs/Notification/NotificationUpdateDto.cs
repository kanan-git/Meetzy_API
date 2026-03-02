namespace Entities.DTOs.Notification;

public class NotificationUpdateDto
{
    public string Info {get; set;}
    public bool IsRead {get; set;}
    public Guid TargetProfileId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
