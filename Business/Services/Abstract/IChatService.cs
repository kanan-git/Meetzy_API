using Entities.DTOs.Chat;

namespace Business.Services.Abstract;

public interface IChatService
{
    public Task<List<ChatResponseDto>> GetAllChats();
    public Task<ChatResponseDto> GetChatById(Guid id);
    public Task CreateChat(ChatCreateDto create);
    public Task UpdateChat(Guid id, ChatUpdateDto update);
    public Task RemoveChat(Guid id);
}
