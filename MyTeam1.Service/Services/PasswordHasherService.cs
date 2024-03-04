using MyTeam_1.Interface;
using System.Security.Cryptography;
using System.Text;

namespace MyTeam_1.Services
{
    public class PasswordHasherService : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedPasswordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedPasswordBytes); 
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {

            string hashedEnteredPassword = HashPassword(enteredPassword);

            return hashedEnteredPassword.Equals(storedHashedPassword);
        }
    }
}
