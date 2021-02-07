using System.Text.Json.Serialization;

namespace JessenMorten.Lifx.Models
{
    public class LifxGroup
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
