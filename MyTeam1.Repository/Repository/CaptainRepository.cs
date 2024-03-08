using Microsoft.EntityFrameworkCore;
using MyTeam_1.Models;
using MyTeam_1.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTeam_1.Repository.Repository
{
    public class CaptainRepository : ICaptainRepository
    {
        private readonly AppDbContext _context;

        public CaptainRepository(AppDbContext context)
        {
            _context = context;
        }
     
        public async Task<List<string>> GetAvailablePlayers(int Roleid)
        {
            var players = await _context.Users
                .Where(x => x.RoleID == Roleid && !x.IsPlaying)
                .Select(x => x.Email)
                .ToListAsync();
            return players;
        }

        public async Task<bool> IsPlayerInTeam(string playerEmail)
        {
            return await _context.Users.AnyAsync(u => u.Email == playerEmail && u.IsPlaying);
        }
        public async Task<bool> IsPlayerRegistered(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddPlayerToTeam(string playerEmail)
        {
            var player = await _context.Users.FirstOrDefaultAsync(u => u.Email == playerEmail);
            if (player != null)
            {
                player.IsPlaying = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> IsPlayerLimit()
        {
            return await _context.Users.CountAsync(u => u.IsPlaying == true);
        }
    }
}
