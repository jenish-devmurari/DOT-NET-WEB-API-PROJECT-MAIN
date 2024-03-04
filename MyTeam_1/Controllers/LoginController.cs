using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTeam_1.DTO;
using MyTeam_1.Interface;
using MyTeam_1DTO;
using System.Threading.Tasks;

namespace MyTeam_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var result = await _loginService.Login(login);
            if (result.Success)
            {
                return Ok(new { token = result.Token });
            }
            return Unauthorized(new { message = result.Message });
        }

        [Authorize]
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDTO update)
        {
            var userId = int.Parse(User.FindFirst("UserId")?.Value);
            var result = await _loginService.UpdatePassword(update, userId);
            return Ok(new { message = result });
        }
    }
}
