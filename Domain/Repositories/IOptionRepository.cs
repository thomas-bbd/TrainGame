using TrainGame.Domain.Models;

namespace TrainGame.Domain.Repository
{
    public interface IOptionRepository
    {
        List<Option> ListAsync();
    }
}