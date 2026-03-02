using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Hashtag;

namespace Business.Services.Concrete;

public class HashtagService : IHashtagService
{
    private readonly IHashtagRepository _hashtagRepo;
    private readonly IMapper _mapper;
    public HashtagService(IHashtagRepository hashtagRepo, IMapper mapper)
    {
        _hashtagRepo = hashtagRepo;
        _mapper = mapper;
    }

    
    public async Task<List<HashtagResponseDto>> GetAllHashtags()
    {
        return _mapper.Map<List<HashtagResponseDto>>(await _hashtagRepo.GetAllAsync());
    }

    public async Task<HashtagResponseDto> GetHashtagById(Guid id)
    {
        var result = await _hashtagRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<HashtagResponseDto>(result);
    }

    public async Task CreateHashtag(HashtagCreateDto create)
    {
        await _hashtagRepo.AddAsync(_mapper.Map<Hashtag>(create));
        var result = await _hashtagRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateHashtag(Guid id, HashtagUpdateDto update)
    {
        var result = await _hashtagRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _hashtagRepo.SaveAsync();
    }

    public async Task RemoveHashtag(Guid id)
    {
        var data = await _hashtagRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _hashtagRepo.Remove(data);
        await _hashtagRepo.SaveAsync();
    }
}
