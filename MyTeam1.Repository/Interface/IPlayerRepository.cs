namespace MyTeam_1.Repository.Interface
{
    public interface IPlayerRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetCoach(int RoleID);

        Task<User> GetCaptain(int RoleID);
    }
}
