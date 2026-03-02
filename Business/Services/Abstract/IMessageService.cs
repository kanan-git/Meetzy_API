using Entities.DTOs.Message;

namespace Business.Services.Abstract;

public interface IMessageService
{
    public Task<List<MessageResponseDto>> GetAllMessages();
    public Task<MessageResponseDto> GetMessageById(Guid id);
    public Task CreateMessage(MessageCreateDto create);
    public Task UpdateMessage(Guid id, MessageUpdateDto update);
    public Task RemoveMessage(Guid id);
}
