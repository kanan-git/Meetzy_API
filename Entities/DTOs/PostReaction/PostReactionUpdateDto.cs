namespace Entities.DTOs.PostReaction;

public class PostReactionUpdateDto
{
    public string ReactionType {get; set;}
    public Guid ProfileId {get; set;}
    public Guid PostId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
