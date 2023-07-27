using System.Net;
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

        public Game CreateGame()
        {
            string id = CreateId();
            Game game = new Game(id);
            game.currentQuestion = _questionService.GetQuestion(ref game.previousQuestions);
            _liveGames.Add(id, game);
            return game;
        }

        public Game NextQuestion(string gameId, String answer)
        {
            Game game;
            if (_liveGames.TryGetValue(gameId, out game)) 
            {
                CheckAnswer(ref game, answer);
                if (!game.gameOver) 
                {
                    Question question = _questionService.GetQuestion(ref game.previousQuestions);
                    game.currentQuestion = question;
                }
                
                return game;
            }
            else
            {
                throw new HttpRequestException("GameId not found", null,  HttpStatusCode.NotFound);
            }
        }

        private void CheckAnswer(ref Game game, string answer)
        {
            if (String.Equals(answer, game.currentQuestion.getHeavierName(), StringComparison.OrdinalIgnoreCase)) //kinda sucks
                {
                    game.IncreaseScore();
                } else {
                    game.gameOver = true;
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