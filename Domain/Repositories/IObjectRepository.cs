using Object = TrainGame.Domain.Models.Object;

namespace TrainGame.Domain.Repository
{
    public interface IObjectRepository
    {
        List<Object> ListAll();
    }
}