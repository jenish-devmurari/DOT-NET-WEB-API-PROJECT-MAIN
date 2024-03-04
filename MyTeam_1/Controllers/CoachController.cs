using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyTeam_1.Interface;

namespace MyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachservice;

        public CoachController(ICoachService service)
        {
            _coachservice = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _coachservice.GetPlayers();
            return Ok(players);
        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddPlayer([FromForm] string Email)
        {
            var result = await _coachservice.AddPlayer(Email);
            return Ok(result);
        }

        [HttpPost("AddCaptain")]
        public async Task<IActionResult> AddCaptain([FromForm] string Email)
        {
            var result = await _coachservice.AddCaptain(Email);
            return Ok(result);
        }

        [HttpPost("ModifyCaptain")]
        public async Task<IActionResult> ModifyCaptain([FromForm] string Email)
        {
            var result = await _coachservice.ModifyCaptain(Email);
            return Ok(result);
        }
    }
}
