namespace Entities.DTOs.Comment;

public class CommentResponseDto
{
    public Guid Id {get; set;}
    public string Text {get; set;}
    public Guid PostId {get; set;}
    public Guid ProfileId {get; set;}
    public Guid? ParentCommentId {get; set;} = null!;
    public DateTime CreatedAt {get; set;}
}
