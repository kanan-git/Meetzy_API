using Entities.DTOs.Hashtag;

namespace Business.Services.Abstract;

public interface IHashtagService
{
    public Task<List<HashtagResponseDto>> GetAllHashtags();
    public Task<HashtagResponseDto> GetHashtagById(Guid id);
    public Task CreateHashtag(HashtagCreateDto create);
    public Task UpdateHashtag(Guid id, HashtagUpdateDto update);
    public Task RemoveHashtag(Guid id);
}
