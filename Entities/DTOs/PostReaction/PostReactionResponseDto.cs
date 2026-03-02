namespace Entities.DTOs.PostReaction;

public class PostReactionResponseDto
{
    public Guid Id {get; set;}
    public string ReactionType {get; set;}
    public Guid ProfileId {get; set;}
    public Guid PostId {get; set;}
}
