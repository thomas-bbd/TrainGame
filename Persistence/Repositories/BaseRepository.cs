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
            optionBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));            
            _context = new AppDbContext(optionBuilder.Options);
        }

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}