using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Comment;

namespace Business.Services.Concrete;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepo;
    private readonly IMapper _mapper;
    public CommentService(ICommentRepository commentRepo, IMapper mapper)
    {
        _commentRepo = commentRepo;
        _mapper = mapper;
    }

    
    public async Task<List<CommentResponseDto>> GetAllComments()
    {
        return _mapper.Map<List<CommentResponseDto>>(await _commentRepo.GetAllAsync());
    }

    public async Task<CommentResponseDto> GetCommentById(Guid id)
    {
        var result = await _commentRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<CommentResponseDto>(result);
    }

    public async Task CreateComment(CommentCreateDto create)
    {
        await _commentRepo.AddAsync(_mapper.Map<Comment>(create));
        var result = await _commentRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateComment(Guid id, CommentUpdateDto update)
    {
        var result = await _commentRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _commentRepo.SaveAsync();
    }

    public async Task RemoveComment(Guid id)
    {
        var data = await _commentRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _commentRepo.Remove(data);
        await _commentRepo.SaveAsync();
    }
}
