using eat_easy_user_BE.Src.Models;

namespace eat_easy_user_BE.Src.Repositories.Interfaces
{
    public interface IActivityLogRepository
    {
        Task<IEnumerable<ActivityLogModel>> GetByUserIdAsync(int id);
        Task AddAsync(ActivityLogModel activityLogModel);
    }
}
