using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyTeam_1.Interface;
using MyTeam_1.Controllers;

namespace MyTeam.Controllers
{
  
    [Authorize(Roles = "1")] //Role-1 iS Assign To Coach
    public class CoachController :BaseController
    {
        private readonly ICoachService _coachservice;

        public CoachController(ICoachService service)
        {
            _coachservice = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
           // var players = await _coachservice.GetPlayers();
            return Ok(await _coachservice.GetPlayers());
        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddPlayer([FromForm] string Email)
        {
           // var result = await _coachservice.AddPlayer(Email);
            return Ok(await _coachservice.AddPlayer(Email));
        }

        [HttpPost("AddCaptain")]
        public async Task<IActionResult> AddCaptain([FromForm] string Email)
        {
           // var result = await _coachservice.AddCaptain(Email);
            return Ok(await _coachservice.AddCaptain(Email));
        }

        [HttpPost("ModifyCaptain")]
        public async Task<IActionResult> ModifyCaptain([FromForm] string Email)
        {
            // var result = await _coachservice.ModifyCaptain(Email);
            return Ok(await _coachservice.ModifyCaptain(Email));
        }
    }
}
