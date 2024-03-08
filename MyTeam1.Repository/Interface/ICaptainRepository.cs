using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeam_1.Repository.Interface
{
    public interface ICaptainRepository
    {
        Task<List<string>> GetAvailablePlayers(int Roleid);
        Task<bool> IsPlayerInTeam(string playerEmail);
        Task<bool> IsPlayerRegistered(string email);
        Task AddPlayerToTeam(string playerEmail);

        Task<int> IsPlayerLimit();
    }
}
