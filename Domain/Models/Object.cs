namespace TrainGame.Domain.Models
{
    public class Object
    {
        public int objectID { get; set; }
        public string objectName { get; set; } = null!;
        public int objectMass { get; set; }
        public List<Train> Trains { get; } = new();        

    }
}