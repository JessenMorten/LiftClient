using System.Text.Json.Serialization;

namespace JessenMorten.LifxClient.Models
{
    public class LifxLocation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
