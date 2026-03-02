namespace Entities.DTOs.Post;

public class PostResponseDto
{
    public Guid Id {get; set;}
    public string TextContent {get; set;}
    public string? Location {get; set;} = null!;
    public Guid ProfileId {get; set;}
    public DateTime CreatedAt {get; set;}
}
