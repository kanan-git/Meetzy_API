using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Message;

namespace Business.Services.Concrete;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepo;
    private readonly IMapper _mapper;
    public MessageService(IMessageRepository messageRepo, IMapper mapper)
    {
        _messageRepo = messageRepo;
        _mapper = mapper;
    }

    
    public async Task<List<MessageResponseDto>> GetAllMessages()
    {
        return _mapper.Map<List<MessageResponseDto>>(await _messageRepo.GetAllAsync());
    }

    public async Task<MessageResponseDto> GetMessageById(Guid id)
    {
        var result = await _messageRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<MessageResponseDto>(result);
    }

    public async Task CreateMessage(MessageCreateDto create)
    {
        await _messageRepo.AddAsync(_mapper.Map<Message>(create));
        var result = await _messageRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateMessage(Guid id, MessageUpdateDto update)
    {
        var result = await _messageRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _messageRepo.SaveAsync();
    }

    public async Task RemoveMessage(Guid id)
    {
        var data = await _messageRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _messageRepo.Remove(data);
        await _messageRepo.SaveAsync();
    }
}
