namespace TrainGame.Domain.Models
{
    public class Train //Idea is that we populate this object based on what's in the DB
    {
        public int trainID { get; set; }
        public string trainName { get; set; } = null!;
        public int trainMass {get; set; }

        public List<Object> Objects { get; } = new();        
    }
}