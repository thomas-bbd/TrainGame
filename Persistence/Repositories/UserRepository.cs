using TrainGame.Domain.Repository;
using User = TrainGame.Domain.Models.User;

namespace TrainGame.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> ListAll()
        {
            IQueryable<User> queryable = _context.Users;
            return queryable.ToList();
        }

        public User GetUser(String userName)
        {
            IQueryable<User> queryable = _context.Users;
            var x = queryable.FirstOrDefault(u => u.userName == userName);
            return x;
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChangesAsync();
        }

        public void UpdateUserScore(User user)
        {
            _context.Users.Update(user);
            _context.SaveChangesAsync();
        }
    }
}