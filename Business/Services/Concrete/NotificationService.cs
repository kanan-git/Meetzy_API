using AutoMapper;

using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions.Content;
using Core.Utilities.Exceptions.Logic;
using DAL.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Notification;

namespace Business.Services.Concrete;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepo;
    private readonly IMapper _mapper;
    public NotificationService(INotificationRepository notificationRepo, IMapper mapper)
    {
        _notificationRepo = notificationRepo;
        _mapper = mapper;
    }

    
    public async Task<List<NotificationResponseDto>> GetAllNotifications()
    {
        return _mapper.Map<List<NotificationResponseDto>>(await _notificationRepo.GetAllAsync());
    }

    public async Task<NotificationResponseDto> GetNotificationById(Guid id)
    {
        var result = await _notificationRepo.GetAsync(ex => ex.Id == id);
        return _mapper.Map<NotificationResponseDto>(result);
    }

    public async Task CreateNotification(NotificationCreateDto create)
    {
        await _notificationRepo.AddAsync(_mapper.Map<Notification>(create));
        var result = await _notificationRepo.SaveAsync();
        if(result == 0)
        {
            throw new DatabaseOperationException(ExceptionMessages.CouldntCreate);
        }
    }

    public async Task UpdateNotification(Guid id, NotificationUpdateDto update)
    {
        var result = await _notificationRepo.GetAsync(ex => ex.Id == id);
        if(result == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _mapper.Map(update, result);
        await _notificationRepo.SaveAsync();
    }

    public async Task RemoveNotification(Guid id)
    {
        var data = await _notificationRepo.GetAsync(ex => ex.Id == id);
        if(data == null)
        {
            throw new ResourceNotFoundException(ExceptionMessages.NotFound);
        }
        _notificationRepo.Remove(data);
        await _notificationRepo.SaveAsync();
    }
}
