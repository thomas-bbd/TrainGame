using TrainGame.Domain.Repository;
using Object = TrainGame.Domain.Models.Object;

namespace TrainGame.Persistence.Repositories
{
    public class ObjectRepository : BaseRepository, IObjectRepository
    {
        public ObjectRepository(IConfiguration configuration) : base(configuration){}

        public List<Object> ListAll()
        {
            IQueryable<Object> queryable = _context.Objects;
            return queryable.ToList();
        }
    }
}