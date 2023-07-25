using TrainGame.Domain.Models;

namespace TrainGame.Domain.Services
{
    public interface IQuestionService
    {
        Question GetQuestion(ref List<Tuple<int, int>> previousPairs);
    }
}

