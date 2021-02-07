using System.Text.Json.Serialization;

namespace JessenMorten.Lifx.Models
{
    public class LifxProduct
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("vendor_id")]
        public int VendorId { get; set; }

        [JsonPropertyName("capabilities")]
        public LifxProductCapabilities Capabilities { get; set; }
    }
}
