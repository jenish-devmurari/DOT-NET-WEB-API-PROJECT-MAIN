using Microsoft.EntityFrameworkCore;
using MyTeam_1.Models;
using MyTeam_1.Repository.Interface;
using System.Threading.Tasks;

namespace MyTeam_1.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetCoach(int RoleID)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RoleID ==  RoleID);
           
        }

        public async Task<User> GetCaptain(int RoleID)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RoleID == RoleID);
        }
    }
}
