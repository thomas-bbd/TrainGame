using Microsoft.EntityFrameworkCore;

namespace TrainGame.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for your database tables
        // For example:
        // public DbSet<Item> Items { get; set; }
        // public DbSet<User> Users { get; set; }
    }
}
