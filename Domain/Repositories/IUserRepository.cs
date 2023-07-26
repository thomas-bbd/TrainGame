using TrainGame.Domain.Models;
using User = TrainGame.Domain.Models.User;

namespace TrainGame.Domain.Repository
{
    public interface IUserRepository
    {
        List<User> ListAll();
        User GetUser(String userName);
        void AddUser(User newUser);
        void UpdateUserScore(User user);
    }
}