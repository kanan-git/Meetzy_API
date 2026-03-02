using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.CommentReaction;

namespace Business.Services.Concrete;

public class CommentReactionService : ICommentReactionService
{
    private readonly ICommentReactionRepository _commentReactionRepo;
    private readonly IMapper _mapper;
    public CommentReactionService(ICommentReactionRepository commentReactionRepo, IMapper mapper)
    {
        _commentReactionRepo = commentReactionRepo;
        _mapper = mapper;
    }

    
    public async Task<List<CommentReactionResponseDto>> GetAllCommentReactions()
    {
        return _mapper.Map<List<CommentReactionResponseDto>>(await _commentReactionRepo.GetAllAsync());
    }

    public async Task<CommentReactionResponseDto> GetCommentReactionById(Guid id)
    {
        var result = await _commentReactionRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<CommentReactionResponseDto>(result);
    }

    public async Task<CommentReactionResponseDto> GetCommentReactionByReactionType(string reactionType)
    {
        var result = await _commentReactionRepo.GetAsync(ex => ex.ReactionType == reactionType);
        return _mapper.Map<CommentReactionResponseDto>(result);
    }

    public async Task CreateCommentReaction(CommentReactionCreateDto create)
    {
        // if(await _commentReactionRepo.IsExistEntity(ex => ex.ReactionType==create.ReactionType))
        // {
        //     throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        // }
        await _commentReactionRepo.AddAsync(_mapper.Map<CommentReaction>(create));
        var result = await _commentReactionRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateCommentReaction(Guid id, CommentReactionUpdateDto update)
    {
        var result = await _commentReactionRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _commentReactionRepo.SaveAsync();
    }

    public async Task RemoveCommentReaction(Guid id)
    {
        var data = await _commentReactionRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _commentReactionRepo.Remove(data);
        await _commentReactionRepo.SaveAsync();
    }
}
