using eat_easy_user_BE.Src.DTOS;

namespace eat_easy_user_BE.Src.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Recupera tutti gli utenti.
        /// </summary>
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();

        /// <summary>
        /// Recupera un utente per ID.
        /// </summary>
        Task<UserDTO> GetUserByIdAsync(int userId);

        /// <summary>
        /// Crea un nuovo utente.
        /// </summary>
        Task<UserDTO> CreateUserAsync(UserCreateDTO userCreateDTO);

        /// <summary>
        /// Aggiorna un utente esistente.
        /// </summary>
        Task<UserDTO> UpdateUserAsync(int userId, UserCreateDTO userUpdateDTO);

        /// <summary>
        /// Cancella un utente.
        /// </summary>
        Task<bool> DeleteUserAsync(int userId);
    }
}
