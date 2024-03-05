using MyTeam_1.DTO;
using MyTeam_1.Interface;
using MyTeam_1DTO;

namespace MyTeam_1.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;

        public LoginService(ILoginRepository loginRepository, IPasswordHasher passwordHasher, IEmailService emailService)
        {
            _loginRepository = loginRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
        }

        public async Task<LoginResultDTO> Login(LoginDTO login)
        {

            var user = await _loginRepository.GetUserByEmailAsync(login.Email);
            if (user != null && _passwordHasher.VerifyPassword(login.Password, user.Password))
            {
                var token = _loginRepository.GenerateToken(user.RoleID,user.UserID);
                return new LoginResultDTO { Success = true, Token = token };
            }
            return new LoginResultDTO { Success = false, Message = "Invalid credentials" };
        }

        public async Task<string> UpdatePassword(UpdatePasswordDTO update, int userId)
        {
            var user = await _loginRepository.GetUserByEmailAsync(update.Email);

            if (user == null)
            {
                return "User not found";
            }

            // Try to change password for another user
            if(userId != user.UserID)
            {
                return "Are You Trying to Change Password Of Another Account Holder";
            }

            var result = _passwordHasher.VerifyPassword(update.Current_Password, user.Password);
            if (!result)
            {
                return "Current password is incorrect";
            }

            user.Password = _passwordHasher.HashPassword(update.New_Password);
            await _loginRepository.UpdateUserAsync(user);
            await _emailService.SendEmailAsync("jenishdevmurari77@gmail.com", update.Email, "Password Change", "Your Password Is Changed Successfully!!!!!!!!");

            return "Password updated successfully";
        }
    }
}