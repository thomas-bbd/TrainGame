using TrainGame.Domain.Models;
using TrainGame.Domain.Repository;

namespace TrainGame.Persistence.Repositories
{
    public class TrainRepository : BaseRepository, ITrainRepository
    {
        public TrainRepository(IConfiguration configuration) : base(configuration){}

        public Task AddAsync(Train train)
        {
            throw new NotImplementedException();
        }

        public Task<Train?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Train> ListAsync()
        {
            IQueryable<Train> queryable = _context.Trains;
            return queryable.ToList();
        }

        public void Remove(Train train)
        {
            throw new NotImplementedException();
        }

        public void Update(Train train)
        {
            throw new NotImplementedException();
        }
    }
}