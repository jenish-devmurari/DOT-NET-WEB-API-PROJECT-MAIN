using Microsoft.EntityFrameworkCore;

namespace MyTeam_1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
