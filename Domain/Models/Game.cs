namespace TrainGame.Domain.Models
{
    public class Game
    {
        public string id { get; set; }
        public int score { get; set; }
        public List<int> previousQuestions = new List<int>();
        
        public Game(string gameId)
        {
            id = gameId;
        }
    }
}