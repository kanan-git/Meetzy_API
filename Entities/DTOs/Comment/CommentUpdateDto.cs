namespace Entities.DTOs.Comment;

public class CommentUpdateDto
{
    public string Text {get; set;}
    public Guid PostId {get; set;}
    public Guid ProfileId {get; set;}
    public Guid? ParentCommentId {get; set;} = null!;
    public DateTime UpdatedAt = DateTime.UtcNow;
}
