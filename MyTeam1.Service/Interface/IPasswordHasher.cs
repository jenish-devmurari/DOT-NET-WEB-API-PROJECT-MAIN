namespace MyTeam_1.Interface
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHashedPassword);
    }
}
