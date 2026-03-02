using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.FriendRequest;

namespace Business.Services.Concrete;

public class FriendRequestService : IFriendRequestService
{
    private readonly IFriendRequestRepository _friendRequestRepo;
    private readonly IMapper _mapper;
    public FriendRequestService(IFriendRequestRepository friendRequestRepo, IMapper mapper)
    {
        _friendRequestRepo = friendRequestRepo;
        _mapper = mapper;
    }

    
    public async Task<List<FriendRequestResponseDto>> GetAllFriendRequests()
    {
        return _mapper.Map<List<FriendRequestResponseDto>>(await _friendRequestRepo.GetAllAsync());
    }

    public async Task<FriendRequestResponseDto> GetFriendRequestById(Guid id)
    {
        var result = await _friendRequestRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<FriendRequestResponseDto>(result);
    }

    public async Task CreateFriendRequest(FriendRequestCreateDto create)
    {
        await _friendRequestRepo.AddAsync(_mapper.Map<FriendRequest>(create));
        var result = await _friendRequestRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateFriendRequest(Guid id, FriendRequestUpdateDto update)
    {
        var result = await _friendRequestRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _friendRequestRepo.SaveAsync();
    }

    public async Task RemoveFriendRequest(Guid id)
    {
        var data = await _friendRequestRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _friendRequestRepo.Remove(data);
        await _friendRequestRepo.SaveAsync();
    }
}
