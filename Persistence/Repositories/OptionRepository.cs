using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;

namespace TrainGame.Persistence.Repositories
{
    public class OptionRepository : BaseRepository, IOptionRepository
    {
        public OptionRepository(IConfiguration configuration) : base(configuration){}
        
        public List<Option> ListAsync()
        {
            IQueryable<Option> queryable = _context.Options;
            return queryable.ToList();
        }
    }
}