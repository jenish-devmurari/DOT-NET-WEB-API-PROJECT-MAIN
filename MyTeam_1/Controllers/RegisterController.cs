
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTeam_1.DTO;
using MyTeam_1.Interface;
using MyTeam_1.Models;
using System.Threading.Tasks;

namespace MyTeam_1.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseController
    {
        private readonly IRegistrationService _registrationService;

        public RegisterController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _registrationService.RegisterUser(model);

            if (result == "User registered successfully")
            {

                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
