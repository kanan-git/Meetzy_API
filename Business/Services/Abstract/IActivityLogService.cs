using Entities.DTOs.ActivityLog;

namespace Business.Services.Abstract;

public interface IActivityLogService
{
    public Task<List<ActivityLogResponseDto>> GetAllActivities();
    public Task<ActivityLogResponseDto> GetActivityLogById(Guid id);
    public Task<ActivityLogResponseDto> GetActivityLogByActionName(string actionName);
    public Task CreateActivity(ActivityLogCreateDto create);
    public Task UpdateActivity(Guid id, ActivityLogUpdateDto update);
    public Task RemoveActivity(Guid id);
}
