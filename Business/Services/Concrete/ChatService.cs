using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Chat;

namespace Business.Services.Concrete;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepo;
    private readonly IMapper _mapper;
    public ChatService(IChatRepository chatRepo, IMapper mapper)
    {
        _chatRepo = chatRepo;
        _mapper = mapper;
    }

    
    public async Task<List<ChatResponseDto>> GetAllChats()
    {
        return _mapper.Map<List<ChatResponseDto>>(await _chatRepo.GetAllAsync());
    }

    public async Task<ChatResponseDto> GetChatById(Guid id)
    {
        var result = await _chatRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<ChatResponseDto>(result);
    }

    public async Task CreateChat(ChatCreateDto create)
    {
        await _chatRepo.AddAsync(_mapper.Map<Chat>(create));
        var result = await _chatRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateChat(Guid id, ChatUpdateDto update)
    {
        var result = await _chatRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _chatRepo.SaveAsync();
    }

    public async Task RemoveChat(Guid id)
    {
        var data = await _chatRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _chatRepo.Remove(data);
        await _chatRepo.SaveAsync();
    }
}
