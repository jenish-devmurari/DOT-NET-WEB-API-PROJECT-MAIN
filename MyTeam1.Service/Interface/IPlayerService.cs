namespace MyTeam.Interface
{
    public interface IPlayerService
    {
        Task<string> GetDetails(string email,int userId);
    }
}
