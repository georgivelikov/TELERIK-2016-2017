using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwJson
{
    public class Video
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public VideoLink VideoLink { get; set; }

        [JsonProperty("media:description")]
        public string Description { get; set; }

        [JsonProperty("published")]
        public DateTime DatePublished { get; set; }
    }

    public class VideoLink
    {
        [JsonProperty("@href")]
        public string Link { get; set; }
    }
}
