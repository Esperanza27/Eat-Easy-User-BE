using AutoMapper;
using eat_easy_user_BE.Src.DTOS;
using eat_easy_user_BE.Src.Models;
using eat_easy_user_BE.Src.Repositories.Interfaces;
using eat_easy_user_BE.Src.Services.Interfaces;

namespace eat_easy_user_BE.Src.Services.Implementations
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;
        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }
        public async Task CreateOrUpdateProfileAsync(UserProfileDTO profileDTO)
        {
            // Verifica se esiste già un profilo per l'utente
            var existingProfile = await _userProfileRepository.GetByUserIdAsync(profileDTO.UserID);
            var profile = _mapper.Map<UserProfileModel>(profileDTO);
            if (existingProfile == null)
            {
                var newProfile = _mapper.Map<UserProfileModel>(profileDTO);
                await _userProfileRepository.AddAsync(newProfile);
            }
            else
            {
                // Se esiste, aggiorna i campi desiderati
                existingProfile.FirstName = profileDTO.FirstName;
                existingProfile.LastName = profileDTO.LastName;
                existingProfile.Age = profileDTO.Age;
                existingProfile.Address = profileDTO.Address;
                existingProfile.Phone = profileDTO.Phone;
                await _userProfileRepository.UpdateAsync(existingProfile);
            }
        }

        public async Task DeleteProfileAsync(int userId)
        {
            await _userProfileRepository.DeleteAsync(userId);
        }

        public async Task<UserProfileDTO> GetProfileByUserIdAsync(int userId)
        {
            var profile = await _userProfileRepository.GetByUserIdAsync(userId);
            return _mapper.Map<UserProfileDTO>(profile);
        }
    }
}
