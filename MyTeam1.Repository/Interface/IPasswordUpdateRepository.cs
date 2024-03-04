using MyTeam_1.Models;
using System.Threading.Tasks;

namespace MyTeam_1.Interface
{
    public interface IPasswordUpdateRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task UpdatePasswordAsync(User user);
    }
}
