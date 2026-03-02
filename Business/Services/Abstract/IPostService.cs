using Entities.DTOs.Post;

namespace Business.Services.Abstract;

public interface IPostService
{
    public Task<List<PostResponseDto>> GetAllPosts();
    public Task<List<PostResponseDto>> GetAllPostsPaginated(int page, int size);
    public Task<PostResponseDto> GetPostById(Guid id);
    public Task CreatePost(PostCreateDto create);
    public Task UpdatePost(Guid id, PostUpdateDto update);
    public Task RemovePost(Guid id);
}
