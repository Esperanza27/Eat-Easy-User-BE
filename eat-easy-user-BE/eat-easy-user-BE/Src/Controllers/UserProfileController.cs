using eat_easy_user_BE.Src.DTOS;
using eat_easy_user_BE.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eat_easy_user_BE.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var profile = await _userProfileService.GetProfileByUserIdAsync(userId);
            if (profile == null) return NotFound();

            return Ok(profile);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateProfile([FromBody] UserProfileDTO profileDTO)
        { 
            await _userProfileService.CreateOrUpdateProfileAsync(profileDTO);
            return Ok(profileDTO);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteProfile(int userId)
        { 
            await _userProfileService.DeleteProfileAsync(userId);
            return NoContent();
        }
    }
}
