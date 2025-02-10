using AutoMapper;
using eat_easy_user_BE.Src.DTOS;
using eat_easy_user_BE.Src.Models;
using eat_easy_user_BE.Src.Repositories.Interfaces;
using eat_easy_user_BE.Src.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace eat_easy_user_BE.Src.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public  UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _userRepository.GetAllUsersAsync());
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("Utente non trovato");

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            try
            {
                var user = _mapper.Map<UserModel>(userCreateDTO);
                user.PasswordHash = _passwordHasher.HashPassword(userCreateDTO.Password);
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                user.IsVerified = false;
                user.Role = "user";

                var createdUser = await _userRepository.AddUserAsync(user);
                return _mapper.Map<UserDTO>(createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SERVICE ERROR]: {ex.Message} - {ex.InnerException?.Message}");
                throw new Exception("Errore durante la creazione dell'utente", ex);
            }
        }
        public async Task<UserDTO> UpdateUserAsync(int userId, UserCreateDTO userUpdateDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("Utente non trovato");

            _mapper.Map(userUpdateDTO, user);
            user.UpdatedAt = DateTime.UtcNow;

            return _mapper.Map<UserDTO>(await _userRepository.UpdateUserByIdAsync(user));
        }
        public async Task<bool> DeleteUserAsync(int userId)
        {
            var deleted = await _userRepository.DeleteUserByIdAsync(userId);
            if (!deleted)
                throw new KeyNotFoundException("Utente non trovato");

            return true;
        }



       
    }
}
