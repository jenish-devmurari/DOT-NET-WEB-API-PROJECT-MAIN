using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Interface;
using MyTeam_1.Controllers;
using MyTeam_1.Interface;

namespace MyTeam.Controllers
{
   
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails([FromForm] string email)
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value);
           // var result = await _playerService.GetDetails(email,userId);
            return Ok(await _playerService.GetDetails(email, userId));
        }
    }
}
