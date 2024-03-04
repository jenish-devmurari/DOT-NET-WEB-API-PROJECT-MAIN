
using Microsoft.EntityFrameworkCore;
using MyTeam_1.Models;
using MyTeam_1.Repository.Interface;
using System.Threading.Tasks;

namespace MyTeam_1.Repository.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _context;

        public RegistrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task RegisterUser(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
