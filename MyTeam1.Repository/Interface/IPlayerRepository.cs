namespace MyTeam_1.Repository.Interface
{
    public interface IPlayerRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetCoach();

        Task<User> GetCaptain();
    }
}
