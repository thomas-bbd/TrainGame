using TrainGame.Domain.Models;
using TrainGame.Domain.Services;
using TrainGame.Domain.Repository;
using Object = TrainGame.Domain.Models.Object;

namespace TrainGame.Services
{
    public class ObjectService : IObjectService
    {
        private readonly IObjectRepository _objectRepository;

        public ObjectService(IObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

        public List<Object> ListAll()
        {
            return  _objectRepository.ListAll();
        }
    }
}