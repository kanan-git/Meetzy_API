namespace Entities.DTOs.CommentReaction;

public class CommentReactionResponseDto
{
    public Guid Id {get; set;}
    public string ReactionType {get; set;}
    public Guid ProfileId {get; set;}
    public Guid CommentId {get; set;}
}
