using TrainGame.Domain.Models;

namespace TrainGame.Domain.Services
{
    public interface ITrainService
    {
        List<Train> ListAsync();
    }
}