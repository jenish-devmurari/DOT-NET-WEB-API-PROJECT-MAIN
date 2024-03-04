namespace MyTeam_1.Interface
{
    public interface ICoachService
    {
        Task<List<string>> GetPlayers();
        Task<string> AddPlayer(string email);
        Task<string> AddCaptain(string email);
        Task<string> ModifyCaptain(string email);
    }
}