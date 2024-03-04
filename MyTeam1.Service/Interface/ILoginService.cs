using MyTeam_1.DTO;
using MyTeam_1DTO;
using System.Threading.Tasks;

namespace MyTeam_1.Interface
{
    public interface ILoginService
    {
        //Task<User> AuthenticateUser(LoginDTO login);
        //string GenerateToken(int role, int userid);
        Task<LoginResultDTO> Login(LoginDTO login);
        Task<string> UpdatePassword(UpdatePasswordDTO update, int userid);
    }
}
