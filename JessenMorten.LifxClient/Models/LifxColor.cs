using System.Text.Json.Serialization;

namespace JessenMorten.LifxClient.Models
{
    public class LifxColor
    {
        [JsonPropertyName("hue")]
        public double Hue { get; set; }

        [JsonPropertyName("saturation")]
        public double Saturation { get; set; }

        [JsonPropertyName("kelvin")]
        public double Kelvin { get; set; }
    }
}
