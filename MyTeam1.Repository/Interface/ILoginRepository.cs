using MyTeam_1.Models;
using System.Threading.Tasks;

namespace MyTeam_1.Interface
{
    public interface ILoginRepository
    {
        string GenerateToken(int roleId, int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int userId);
        Task UpdateUserAsync(User user);
    }
}
