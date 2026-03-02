namespace Entities.DTOs.PostReaction;

public class PostReactionCreateDto
{
    public string ReactionType {get; set;}
    public Guid ProfileId {get; set;}
    public Guid PostId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
