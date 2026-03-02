using Entities.DTOs.Comment;

namespace Business.Services.Abstract;

public interface ICommentService
{
    public Task<List<CommentResponseDto>> GetAllComments();
    public Task<CommentResponseDto> GetCommentById(Guid id);
    public Task CreateComment(CommentCreateDto create);
    public Task UpdateComment(Guid id, CommentUpdateDto update);
    public Task RemoveComment(Guid id);
}
