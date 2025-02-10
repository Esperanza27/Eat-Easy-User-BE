using eat_easy_user_BE.Src.Models;

namespace eat_easy_user_BE.Src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<UserModel> UpdateUserByIdAsync(UserModel user);
        Task<bool> DeleteUserByIdAsync(int id);
    }
}
