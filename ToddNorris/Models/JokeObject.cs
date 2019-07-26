using Newtonsoft.Json;

namespace ToddNorris.Models
{
    public class JokeObject
    {
        [JsonProperty("value")] public string Value { get; set; }
    }
}