namespace Entities.DTOs.Comment;

public class CommentCreateDto
{
    public string Text {get; set;}
    public Guid PostId {get; set;}
    public Guid ProfileId {get; set;}
    public Guid? ParentCommentId {get; set;} = null!;
    public DateTime CreatedAt = DateTime.UtcNow;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
