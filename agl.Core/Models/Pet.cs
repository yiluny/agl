using Newtonsoft.Json;

namespace agl.Core.Models
{
    [JsonObject]
    public class Pet
    {
        [JsonProperty(PropertyName = "type")]
        public AnimalType Type { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}