using Microsoft.EntityFrameworkCore;
using MyTeam_1.Interface;
using MyTeam_1.Models;
using MyTeam_1.Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeam_1.Repository
{
    public class CoachRepository : ICoachRepository
    {
        private readonly AppDbContext _context;

        public CoachRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetPlayers()
        {
            return await _context.Users
                .Where(x => x.RoleID == 0)
                .Select(x => x.Email)
                .ToListAsync();
        }


        public async Task<bool> IsPlayerRegister(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && (u.RoleID == 0));
        }

        public async Task<bool> IsPlayerAdded(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && (u.RoleID == 2 || u.RoleID == 3));
        }

        public async Task<bool> IsPlayerInSquad(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.RoleID == 3);
        }

        public async Task<bool> IsCaptainAdded()
        {
            return await _context.Users.AnyAsync(u => u.RoleID == 2);
        }

        public async Task<int> IsPlayerLimit()
        {
            return await _context.Users.CountAsync(u => u.RoleID == 2 || u.RoleID == 3);
        }

        public async Task AddPlayerToSquad(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                user.RoleID = 3;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddCaptain(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                user.RoleID = 2;
                user.IsPlaying = true;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> ModifyCaptain(string email)
        {
            var existingCaptain = await _context.Users.FirstOrDefaultAsync(u => u.RoleID == 2);
            string oldCaptainEmail = null;

            if (existingCaptain != null)
            {
                oldCaptainEmail = existingCaptain.Email;
                existingCaptain.RoleID = 3;
                existingCaptain.IsPlaying = false;
                _context.Users.Update(existingCaptain);
            }

            var newCaptain = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (newCaptain != null)
            {
                newCaptain.RoleID = 2;
                newCaptain.IsPlaying = true;
                _context.Users.Update(newCaptain);
            }

            await _context.SaveChangesAsync();

            return oldCaptainEmail;
        }
    }
}
