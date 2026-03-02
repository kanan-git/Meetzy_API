using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.ActivityLog;

namespace Business.Services.Concrete;

public class ActivityLogService : IActivityLogService
{
    private readonly IActivityLogRepository _activityRepo;
    private readonly IMapper _mapper;
    public ActivityLogService(IActivityLogRepository activityRepo, IMapper mapper)
    {
        _activityRepo = activityRepo;
        _mapper = mapper;
    }

    
    public async Task<List<ActivityLogResponseDto>> GetAllActivities()
    {
        return _mapper.Map<List<ActivityLogResponseDto>>(await _activityRepo.GetAllAsync());
    }

    public async Task<ActivityLogResponseDto> GetActivityLogById(Guid id)
    {
        var result = await _activityRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<ActivityLogResponseDto>(result);
    }

    public async Task<ActivityLogResponseDto> GetActivityLogByActionName(string actionName)
    {
        var result = await _activityRepo.GetAsync(ex => ex.Action == actionName);
        return _mapper.Map<ActivityLogResponseDto>(result);
    }

    public async Task CreateActivity(ActivityLogCreateDto create)
    {
        if(await _activityRepo.IsExistEntity(ex => ex.Action==create.Action))
        {
            throw new AlreadyExistException(ExceptionMessages.AlreadyExist);
        }
        await _activityRepo.AddAsync(_mapper.Map<ActivityLog>(create));
        var result = await _activityRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateActivity(Guid id, ActivityLogUpdateDto update)
    {
        var result = await _activityRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _activityRepo.SaveAsync();
    }

    public async Task RemoveActivity(Guid id)
    {
        var data = await _activityRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _activityRepo.Remove(data);
        await _activityRepo.SaveAsync();
    }
}
