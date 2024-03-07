using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTeam_1.Controllers;
using MyTeam_1.Interface;

namespace MyTeam.Controllers
{

    [Authorize(Roles = "2")] //Role-2 Is Assign To Captian
    public class CaptainController : BaseController
    {
        private readonly ICaptainService _captainService;

        public CaptainController(ICaptainService captainService)
        {
            _captainService = captainService;
        }

        [HttpGet("AvailablePlayers")]
        public async Task<IActionResult> GetAvailablePlayers()
        {
            // var players = await _captainService.GetPlayerList();
            return Ok(await _captainService.GetPlayerList());

        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddPlayerToTeam([FromForm] string playerEmail)
        {
           //  var result = await _captainService.AddPlayerToTeam(playerEmail);
            return Ok(await _captainService.AddPlayerToTeam(playerEmail));
        }
    }
}
