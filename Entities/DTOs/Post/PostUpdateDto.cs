namespace Entities.DTOs.Post;

public class PostUpdateDto
{
    public string TextContent {get; set;}
    public string? Location {get; set;} = null!;
    public Guid ProfileId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
