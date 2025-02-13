using eat_easy_user_BE.Src.DTOS;

namespace eat_easy_user_BE.Src.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDTO> GetProfileByUserIdAsync(int userId);
        Task CreateOrUpdateProfileAsync(UserProfileDTO profileDTO);
        Task DeleteProfileAsync (int userId);
    }
}
