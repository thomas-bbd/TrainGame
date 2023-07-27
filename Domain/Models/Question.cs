namespace TrainGame.Domain.Models
{
    public class Question //Idea is that we populate this object based on what's in the DB
    {
        public Train Train { get; set; } = null!;
        public Object Object { get; set; } = null!;

        public bool isObjectHeavier()
        {
            return Object.objectMass > Train.trainMass;
        }

        public string getHeavierName()
        {
            return Object.objectMass > Train.trainMass ? Object.objectName : Train.trainName;
        }

    }
}