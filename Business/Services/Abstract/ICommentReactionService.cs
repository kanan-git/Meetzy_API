using Entities.DTOs.CommentReaction;

namespace Business.Services.Abstract;

public interface ICommentReactionService
{
    public Task<List<CommentReactionResponseDto>> GetAllCommentReactions();
    public Task<CommentReactionResponseDto> GetCommentReactionById(Guid id);
    public Task<CommentReactionResponseDto> GetCommentReactionByReactionType(string reactionType);
    public Task CreateCommentReaction(CommentReactionCreateDto create);
    public Task UpdateCommentReaction(Guid id, CommentReactionUpdateDto update);
    public Task RemoveCommentReaction(Guid id);
}
