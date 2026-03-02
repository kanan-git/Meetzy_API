using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.PostReaction;

namespace Business.Services.Concrete;

public class PostReactionService : IPostReactionService
{
    private readonly IPostReactionRepository _postReactionRepo;
    private readonly IMapper _mapper;
    public PostReactionService(IPostReactionRepository postReactionRepo, IMapper mapper)
    {
        _postReactionRepo = postReactionRepo;
        _mapper = mapper;
    }

    
    public async Task<List<PostReactionResponseDto>> GetAllPostReactions()
    {
        return _mapper.Map<List<PostReactionResponseDto>>(await _postReactionRepo.GetAllAsync());
    }

    public async Task<PostReactionResponseDto> GetPostReactionById(Guid id)
    {
        var result = await _postReactionRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<PostReactionResponseDto>(result);
    }

    public async Task<PostReactionResponseDto> GetPostReactionByReactionType(string reactionType)
    {
        var result = await _postReactionRepo.GetAsync(ex => ex.ReactionType == reactionType);
        return _mapper.Map<PostReactionResponseDto>(result);
    }

    public async Task CreatePostReaction(PostReactionCreateDto create)
    {
        // if(await _postReactionRepo.IsExistEntity(ex => ex.ReactionType==create.ReactionType))
        // {
        //     throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        // }
        await _postReactionRepo.AddAsync(_mapper.Map<PostReaction>(create));
        var result = await _postReactionRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdatePostReaction(Guid id, PostReactionUpdateDto update)
    {
        var result = await _postReactionRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _postReactionRepo.SaveAsync();
    }

    public async Task RemovePostReaction(Guid id)
    {
        var data = await _postReactionRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _postReactionRepo.Remove(data);
        await _postReactionRepo.SaveAsync();
    }
}
