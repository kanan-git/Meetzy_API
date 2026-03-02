using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Post;

namespace Business.Services.Concrete;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepo;
    private readonly IMapper _mapper;
    public PostService(IPostRepository postRepo, IMapper mapper)
    {
        _postRepo = postRepo;
        _mapper = mapper;
    }

    
    public async Task<List<PostResponseDto>> GetAllPosts()
    {
        return _mapper.Map<List<PostResponseDto>>(await _postRepo.GetAllAsync());
    }

    public async Task<List<PostResponseDto>> GetAllPostsPaginated(int page, int size)
    {
        return _mapper.Map<List<PostResponseDto>>(await _postRepo.GetAllWithPaginatedAsync(page, size));
    }

    public async Task<PostResponseDto> GetPostById(Guid id)
    {
        var result = await _postRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<PostResponseDto>(result);
    }

    public async Task CreatePost(PostCreateDto create)
    {
        await _postRepo.AddAsync(_mapper.Map<Post>(create));
        var result = await _postRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdatePost(Guid id, PostUpdateDto update)
    {
        var result = await _postRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _postRepo.SaveAsync();
    }

    public async Task RemovePost(Guid id)
    {
        var data = await _postRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _postRepo.Remove(data);
        await _postRepo.SaveAsync();
    }
}
