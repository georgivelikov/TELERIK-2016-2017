using Newtonsoft.Json;

namespace JsonImporter.Models
{
    public class JsonCity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("planet")]
        public string Planet { get; set; }
    }
}
