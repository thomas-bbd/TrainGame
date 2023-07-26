using TrainGame.Domain.Models;

namespace TrainGame.Domain.Repository
{
    public interface ITrainRepository
    {
        List<Train> ListAsync();
		Task AddAsync(Train train);
		Task<Train?> FindByIdAsync(int id);
		void Update(Train train);
		void Remove(Train train);
    }
}