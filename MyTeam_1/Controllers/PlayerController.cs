using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTeam.Interface;
using MyTeam_1.Interface;

namespace MyTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<string> GetDetails([FromForm] string email)
        {
            var result = await _playerService.GetDetails(email);
            return result;
        }
    }
}
