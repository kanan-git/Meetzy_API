using Entities.DTOs.PostReaction;

namespace Business.Services.Abstract;

public interface IPostReactionService
{
    public Task<List<PostReactionResponseDto>> GetAllPostReactions();
    public Task<PostReactionResponseDto> GetPostReactionById(Guid id);
    public Task<PostReactionResponseDto> GetPostReactionByReactionType(string reactionType);
    public Task CreatePostReaction(PostReactionCreateDto create);
    public Task UpdatePostReaction(Guid id, PostReactionUpdateDto update);
    public Task RemovePostReaction(Guid id);
}
