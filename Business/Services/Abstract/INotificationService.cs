using Entities.DTOs.Notification;

namespace Business.Services.Abstract;

public interface INotificationService
{
    public Task<List<NotificationResponseDto>> GetAllNotifications();
    public Task<NotificationResponseDto> GetNotificationById(Guid id);
    public Task CreateNotification(NotificationCreateDto create);
    public Task UpdateNotification(Guid id, NotificationUpdateDto update);
    public Task RemoveNotification(Guid id);
}
