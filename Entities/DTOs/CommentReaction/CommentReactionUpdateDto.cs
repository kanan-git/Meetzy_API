namespace Entities.DTOs.CommentReaction;

public class CommentReactionUpdateDto
{
    public string ReactionType {get; set;}
    public Guid ProfileId {get; set;}
    public Guid CommentId {get; set;}
    public DateTime UpdatedAt = DateTime.UtcNow;
}
