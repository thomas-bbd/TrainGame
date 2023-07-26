using Microsoft.EntityFrameworkCore;
using TrainGame.Domain.Models;
using Object = TrainGame.Domain.Models.Object;

namespace TrainGame.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
