namespace Entities.DTOs.Post;

public class PostCreateDto
{
    public string TextContent {get; set;}
    public string? Location {get; set;} = null!;
    public Guid ProfileId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
