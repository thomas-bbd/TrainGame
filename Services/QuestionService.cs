using TrainGame.Domain.Models;
using TrainGame.Domain.Services;
using Object = TrainGame.Domain.Models.Object;

namespace TrainGame.Services 
{
    public class QuestionService : IQuestionService
    {
        private readonly ITrainService _trainService;
        private readonly IObjectService _objectService;
        private readonly IRandomGeneratorService _randomGenerator;
        private List<Train> _trains;
        private List<Object> _objects;

        public QuestionService(ITrainService trainService, IObjectService objectService, IRandomGeneratorService randomGenerator)
        {
            _trainService = trainService;
            _objectService = objectService;
            _randomGenerator = randomGenerator;
            _trains = trainService.ListAsync();
            _objects = _objectService.ListAll();
        }

        public Question GetQuestion(ref List<Tuple<int, int>> previousPairs)
        {
            Tuple<int, int> questionPair = GetQuestionNumber(previousPairs);
            Question question = new Question();
            if(questionPair.Item1 != -1 && questionPair.Item2 != -1) //ideally GetQuestionNumber is throwing an exception instead of this
            {
                question.Train = _trains[questionPair.Item1];
                question.Object = _objects[questionPair.Item2];
            }
            previousPairs.Add(questionPair);
            return question;
        }

        private Tuple<int, int> GetQuestionNumber(List<Tuple<int, int>> previousPairs)
        {
            int q1 = 0;
            int q2 = 0;

            bool hasPair = previousPairs.Any(t => (t.Item1 == q1 && t.Item2 == q2));
            int numAttempts = 0;
            while (hasPair)
            {
                numAttempts++;
                q1 = _randomGenerator.RandomInt(0, _trains.Count);
                q2 = _randomGenerator.RandomInt(0, _objects.Count);
                hasPair = previousPairs.Any(t => (t.Item1 == q1 && t.Item2 == q2));
                if (numAttempts == _objects.Count * 2) //Should find a better way for this
                {
                    q1 = -1;
                    q2 = -1;
                    hasPair = true;
                    //Should actually be throwing custom exception here
                }
            }
            return new Tuple<int, int>(q1, q2);
        }
    }
}