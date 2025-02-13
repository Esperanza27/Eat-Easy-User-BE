using eat_easy_user_BE.Src.Data;
using eat_easy_user_BE.Src.Models;
using eat_easy_user_BE.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eat_easy_user_BE.Src.Repositories.Implementations
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ActivityLogModel activityLogModel)
        {
            await _context.ActivityLogs.AddAsync(activityLogModel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ActivityLogModel>> GetByUserIdAsync(int userId)
        {
            return await _context.ActivityLogs
                                .Where(log => log.UserId == userId)
                                .ToListAsync();

        }
    }
}
