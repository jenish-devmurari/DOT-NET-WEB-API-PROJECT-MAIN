using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTeam_1.Interface;

namespace MyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "2")]
    public class CaptainController : ControllerBase
    {
        private readonly ICaptainService _captainService;

        public CaptainController(ICaptainService captainService)
        {
            _captainService = captainService;
        }

        [HttpGet("AvailablePlayers")]
        public async Task<IActionResult> GetAvailablePlayers()
        {
            var players = await _captainService.GetPlayerList();
            return Ok(players);
        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddPlayerToTeam([FromForm] string playerEmail)
        {
            var result = await _captainService.AddPlayerToTeam(playerEmail);
            return Ok(result);
        }
    }
}
