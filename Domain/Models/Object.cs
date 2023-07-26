using System.Text.Json.Serialization;

namespace TrainGame.Domain.Models
{
    public class Object
    {
        [JsonIgnore]
        public int objectID { get; set; }
        public string objectName { get; set; } = null!;
        [JsonIgnore]
        public int objectMass { get; set; }     

    }
}