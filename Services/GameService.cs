using TrainGame.Domain.Models;
using TrainGame.Domain.Services;

namespace TrainGame.Services 
{
    public class GameService : IGameService
    {
        private Dictionary<string, Game> _liveGames = new Dictionary<string, Game>();
        private IRandomGeneratorService _randomGenerator;
        private IQuestionService _questionService;
        
        public GameService(IRandomGeneratorService randomGeneratorService, IQuestionService questionService)
        {
            _liveGames = new Dictionary<string, Game>();
            _randomGenerator = randomGeneratorService;
            _questionService = questionService;
        }

        public bool CheckAnswer(string gameId, string answer)
        {
            //if correct send object containing score and next question? Or Just score and user clicks a button to get next question?
            //if incorrect redirect to game over screen? Or send incorrect and user clicks button?
            Game game;
            if (_liveGames.TryGetValue(gameId, out game)) 
            {
                if (!game.gameOver){
                    if (String.Equals(answer, "YES", StringComparison.OrdinalIgnoreCase) && game.currentQuestion.isObjectHeavier()) //kinda sucks
                    {
                        game.IncreaseScore();
                        return true;
                    } else if (String.Equals(answer, "NO", StringComparison.OrdinalIgnoreCase) && !game.currentQuestion.isObjectHeavier()){
                        return true; //??
                    } else {
                        game.gameOver = true;
                        return false;
                    }
                }
                else
                {
                    return false; //??
                }
            }
            else
            {
                throw new ArgumentException("gameId doesn't correspond to a game");
            }
        }

        public Game CreateGame()
        {
            string id = CreateId();
            Game game = new Game(id);
            _liveGames.Add(id, game);
            return game;
        }

        public Game NextQuestion(string gameId)
        {
            Game game;
            if (_liveGames.TryGetValue(gameId, out game)) 
            {
                Question question = _questionService.GetQuestion(ref game.previousQuestions);
                game.currentQuestion = question;
                return game;
            }
            else
            {
                throw new ArgumentException("gameId doesn't correspond to a game");
            }
        }

        private string CreateId()
        {
            string id = _randomGenerator.RandomString(10);
            while (_liveGames.ContainsKey(id)) {
                id = _randomGenerator.RandomString(10);
            }
            return id;
        }
    }
}