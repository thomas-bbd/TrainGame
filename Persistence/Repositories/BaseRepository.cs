using TrainGame.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using TrainGame.Domain.Models;

namespace TrainGame.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            string url = Environment.GetEnvironmentVariable("DB_STRING") ?? String.Empty;       
            optionBuilder.UseMySql(url, ServerVersion.AutoDetect(url));            
            _context = new AppDbContext(optionBuilder.Options);
        }

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}