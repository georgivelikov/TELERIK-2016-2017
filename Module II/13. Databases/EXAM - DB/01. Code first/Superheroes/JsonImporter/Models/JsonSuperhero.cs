using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace JsonImporter.Models
{
    public class JsonSuperhero
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secretIdentity")]
        public string SecretIdentity { get; set; }

        [JsonProperty("city")]
        public JsonCity City { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }

        [JsonProperty("story")]
        public string Story { get; set; }

        [JsonProperty("powers")]
        public string[] Powers { get; set; }

        [JsonProperty("fractions")]
        public string[] Fractions { get; set; } 
    }
}
