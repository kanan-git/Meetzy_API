namespace Entities.DTOs.Notification;

public class NotificationResponseDto
{
    public Guid Id {get; set;}
    public string Info {get; set;}
    public bool IsRead {get; set;}
    public Guid TargetProfileId {get; set;}
    public DateTime CreatedAt {get; set;}
}
