using TrainGame.Domain.Models;
using Object = TrainGame.Domain.Models.Object;

namespace TrainGame.Domain.Services
{
    public interface IObjectService
    {
        List<Object> ListAll();
    }
}

