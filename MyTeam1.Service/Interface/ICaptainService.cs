using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTeam_1.Interface
{
    public interface ICaptainService
    {
        Task<List<string>> GetPlayerList();
        Task<string> AddPlayerToTeam(string playerEmail);
    }
}
