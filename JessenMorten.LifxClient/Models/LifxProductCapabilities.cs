using System.Text.Json.Serialization;

namespace JessenMorten.LifxClient.Models
{
    public class LifxProductCapabilities
    {
        [JsonPropertyName("has_color")]
        public bool HasColor { get; set; }

        [JsonPropertyName("has_variable_color_temp")]
        public bool HasVariableColorTemp { get; set; }

        [JsonPropertyName("has_ir")]
        public bool HasIr { get; set; }

        [JsonPropertyName("has_chain")]
        public bool HasChain { get; set; }

        [JsonPropertyName("has_matrix")]
        public bool HasMatrix { get; set; }

        [JsonPropertyName("has_multizone")]
        public bool HasMultizone { get; set; }

        [JsonPropertyName("min_kelvin")]
        public double MinKelvin { get; set; }

        [JsonPropertyName("max_kelvin")]
        public double MaxKelvin { get; set; }
    }
}
