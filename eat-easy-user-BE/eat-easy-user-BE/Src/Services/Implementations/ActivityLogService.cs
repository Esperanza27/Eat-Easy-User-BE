using AutoMapper;
using eat_easy_user_BE.Src.DTOS;
using eat_easy_user_BE.Src.Models;
using eat_easy_user_BE.Src.Repositories.Interfaces;
using eat_easy_user_BE.Src.Services.Interfaces;

namespace eat_easy_user_BE.Src.Services.Implementations
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IMapper _mapper;

        public ActivityLogService(IActivityLogRepository activityLogRepository, IMapper mapper)
        {
            _activityLogRepository = activityLogRepository;
            _mapper = mapper;
        }

        public async Task AddLogAsync(ActivityLogCreateDTO logDto)
        {
            var log = _mapper.Map<ActivityLogModel>(logDto);
            // Imposta il timestamp corrente, se non lo hai già impostato nel DTO
            log.Timestamp = DateTime.UtcNow;
            await _activityLogRepository.AddAsync(log);
        }

        public async Task<IEnumerable<ActivityLogDTO>> GetLogsByUserIdAsync(int userId)
        {
            var logs = await _activityLogRepository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ActivityLogDTO>>(logs);
        }
    }
}
