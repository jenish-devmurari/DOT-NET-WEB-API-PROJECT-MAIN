using Microsoft.EntityFrameworkCore;
using MyTeam_1.Interface;
using MyTeam_1.Models;
using System;
using System.Threading.Tasks;

namespace MyTeam_1.Repositories
{
    public class PasswordUpdateRepository : IPasswordUpdateRepository

    {
        private readonly AppDbContext _context;

        public PasswordUpdateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdatePasswordAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
