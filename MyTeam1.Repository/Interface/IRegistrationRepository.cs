
using MyTeam_1.Models;
using System.Threading.Tasks;

namespace MyTeam_1.Repository.Interface
{
    public interface IRegistrationRepository
    {
        Task RegisterUser(User model);
        Task<User> GetUserByEmailAsync(string email);
    }
}
