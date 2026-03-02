namespace Entities.DTOs.ActivityLog;

public class ActivityLogUpdateDto
{
    public string Action {get; set;}
    public string? Details {get; set;} = null!;
    public string? IpV4Address {get; set;} = null!;
    public string? IpV6Address {get; set;} = null!;
    public Guid ProfileId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
