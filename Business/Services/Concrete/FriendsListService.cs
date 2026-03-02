using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.FriendsList;

namespace Business.Services.Concrete;

public class FriendsListService : IFriendsListService
{
    private readonly IFriendsListRepository _friendsListRepo;
    private readonly IMapper _mapper;
    public FriendsListService(IFriendsListRepository friendsListRepo, IMapper mapper)
    {
        _friendsListRepo = friendsListRepo;
        _mapper = mapper;
    }

    
    public async Task<List<FriendsListResponseDto>> GetAllFriendsLists()
    {
        return _mapper.Map<List<FriendsListResponseDto>>(await _friendsListRepo.GetAllAsync());
    }

    public async Task<FriendsListResponseDto> GetFriendsListById(Guid id)
    {
        var result = await _friendsListRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<FriendsListResponseDto>(result);
    }

    public async Task CreateFriendsList(FriendsListCreateDto create)
    {
        await _friendsListRepo.AddAsync(_mapper.Map<FriendsList>(create));
        var result = await _friendsListRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateFriendsList(Guid id, FriendsListUpdateDto update)
    {
        var result = await _friendsListRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _friendsListRepo.SaveAsync();
    }

    public async Task RemoveFriendsList(Guid id)
    {
        var data = await _friendsListRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _friendsListRepo.Remove(data);
        await _friendsListRepo.SaveAsync();
    }
}
