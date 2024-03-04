namespace MyTeam_1.Interface
{
    public interface ICoachRepository
    {
        Task<List<string>> GetPlayers();

        Task<bool> IsPlayerRegister(string email);
        Task<bool> IsPlayerAdded(string email);
        Task<bool> IsPlayerInSquad(string email);
        Task<bool> IsCaptainAdded();
        Task<int> IsPlayerLimit();
        Task AddPlayerToSquad(string email);
        Task AddCaptain(string email);
        Task<string> ModifyCaptain(string email);
    }
}
