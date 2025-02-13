using eat_easy_user_BE.Src.DTOS;
using eat_easy_user_BE.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eat_easy_user_BE.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private readonly IActivityLogService _activityLogService;

        public ActivityLogController(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLogsByUserId (int userId)
        {
            IEnumerable<ActivityLogDTO> logs = await _activityLogService.GetLogsByUserIdAsync (userId);
            // Se non si trovano log, è possibile restituire NotFound oppure una lista vuota
            if (logs == null)
            {
                return NotFound($"Nessun log trovato per l'utente con ID {userId}.");
            }
            return Ok(logs);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> AddLog([FromBody] ActivityLogCreateDTO logDto)
        {
            if (logDto == null)
            {
                return BadRequest("I dati del log non possono essere nulli.");
            }
            // Se hai attributi di validazione nel DTO, [ApiController] si occuperà di controllarli automaticamente

            await _activityLogService.AddLogAsync(logDto);

            // Puoi restituire lo stesso oggetto, oppure utilizzare CreatedAtAction per indicare l'URI della nuova risorsa
            return Ok(logDto);
        }
    }
}
