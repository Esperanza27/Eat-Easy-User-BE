using eat_easy_user_BE.Src.DTOS;

namespace eat_easy_user_BE.Src.Services.Interfaces
{
    public interface IActivityLogService
    {
        Task<IEnumerable<ActivityLogDTO>> GetLogsByUserIdAsync(int userId);
        Task AddLogAsync(ActivityLogCreateDTO logDto);

    }
}
