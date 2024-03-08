using Microsoft.EntityFrameworkCore.Query;

namespace MyTeam_1.Interface
{
    public interface ICoachRepository
    {
        Task<List<string>> GetPlayers(int Roleid);

        Task<bool> IsPlayerRegister(string email);
        Task<bool> IsPlayerAdded(string email,int roleid1,int roleid2);
        Task<bool> IsPlayerInSquad(string email,int roleid);
        Task<bool> IsCaptainAdded();
        Task<int> IsPlayerLimit();
        Task AddPlayerToSquad(string email);
        Task AddCaptain(string email);
        Task<string> ModifyCaptain(string email);
    }
}
