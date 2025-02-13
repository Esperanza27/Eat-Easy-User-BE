using eat_easy_user_BE.Src.Models;

namespace eat_easy_user_BE.Src.Repositories.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfileModel> GetByUserIdAsync(int userId);
        Task AddAsync(UserProfileModel profile);
        Task UpdateAsync(UserProfileModel profile);
        Task<bool> DeleteAsync(int userId);
    }
}
