using System;
using System.Text.Json.Serialization;

namespace JessenMorten.Lifx.Models
{
    public class LifxBulb
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("connected")]
        public bool Connected { get; set; }

        [JsonPropertyName("power")]
        public string Power { get; set; }

        [JsonPropertyName("color")]
        public LifxColor Color { get; set; }

        [JsonPropertyName("brightness")]
        public double Brightness { get; set; }

        [JsonPropertyName("group")]
        public LifxGroup Group { get; set; }

        [JsonPropertyName("location")]
        public LifxLocation Location { get; set; }

        [JsonPropertyName("product")]
        public LifxProduct Product { get; set; }

        [JsonPropertyName("last_seen")]
        public DateTime LastSeen { get; set; }

        [JsonPropertyName("seconds_since_seen")]
        public int SecondsSinceSeen { get; set; }
    }
}
