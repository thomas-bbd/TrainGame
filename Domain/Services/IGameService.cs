using TrainGame.Domain.Models;

namespace TrainGame.Domain.Services
{
    public interface IGameService
    {
        Game CreateGame();
        Game NextQuestion(string gameId, string answer);
    }
}

