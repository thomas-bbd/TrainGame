using TrainGame.Domain.Models;
using TrainGame.Domain.Services;
using TrainGame.Domain.Repository;

namespace TrainGame.Services
{
    public class TrainService : ITrainService
    {
        private readonly ITrainRepository _trainRepository;

        public TrainService(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public List<Train> ListAsync()
        {
            return  _trainRepository.ListAsync();
        }
    }
}