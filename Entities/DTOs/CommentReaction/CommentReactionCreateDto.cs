namespace Entities.DTOs.CommentReaction;

public class CommentReactionCreateDto
{
    public string ReactionType {get; set;}
    public Guid ProfileId {get; set;}
    public Guid CommentId {get; set;}
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
