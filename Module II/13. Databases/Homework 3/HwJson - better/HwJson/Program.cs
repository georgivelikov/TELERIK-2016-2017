using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HwJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = @"https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string xmlFile = @"../../videos.xml";
            WebClient client = new WebClient();
            var downloadedData=client.DownloadData(url);
            string encodedXml = Encoding.UTF8.GetString(downloadedData);
            File.WriteAllText(xmlFile, encodedXml);

            var xmlDoc = XDocument.Parse(encodedXml);
            var jsonData = JsonConvert.SerializeXNode(xmlDoc);
            var jsonObject = JObject.Parse(jsonData);
            var titles = jsonObject["feed"]["entry"].Select(jt => jt.Value<string>("title"));
            Console.WriteLine("Video titles");
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            var partialJson = jsonObject["feed"]["entry"].ToString();
            var PocoVideos = JsonConvert.DeserializeObject<List<Video>>(partialJson);
        }
    }
}
