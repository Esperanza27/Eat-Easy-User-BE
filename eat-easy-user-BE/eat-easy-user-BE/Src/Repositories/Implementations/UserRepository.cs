using eat_easy_user_BE.Src.Data;
using eat_easy_user_BE.Src.Models;
using eat_easy_user_BE.Src.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace eat_easy_user_BE.Src.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get All
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        //Get Id
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        //Create
        public async Task<UserModel> AddUserAsync (UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        //Update
        public async Task<UserModel> UpdateUserByIdAsync(UserModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        //Delete
        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
