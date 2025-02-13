using eat_easy_user_BE.Src.Data;
using eat_easy_user_BE.Src.Models;
using eat_easy_user_BE.Src.Repositories.Interfaces;

namespace eat_easy_user_BE.Src.Repositories.Implementations
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context)
        { 
            _context = context;
        }
        public async Task AddAsync(UserProfileModel profile)
        {
            await _context.UserProfiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int userId)
        {
            var profile = await _context.UserProfiles.FindAsync(userId);
            if (profile == null) return false;
            _context.UserProfiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserProfileModel> GetByUserIdAsync(int userId)
        {
           return await _context.UserProfiles.FindAsync(userId);
        }

        public async Task UpdateAsync(UserProfileModel profile)
        {
            _context.UserProfiles.Update(profile);
            await _context.SaveChangesAsync();  
        }
    }
}
