using System.Text.Json.Serialization;

namespace TrainGame.Domain.Models
{
    public class Train //Idea is that we populate this object based on what's in the DB
    {
        [JsonIgnore]
        public int trainID { get; set; }
        public string trainName { get; set; } = null!;
        [JsonIgnore]
        public int trainMass {get; set; }     
    }
}