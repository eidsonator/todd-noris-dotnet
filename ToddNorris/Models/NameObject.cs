using Newtonsoft.Json;

namespace ToddNorris.Models
{
    public class NameObject
    {
        [JsonProperty("firstName")] public string FirstName { get; set; }
        
        [JsonProperty("lastName")] public string LastName { get; set; }
    }
}