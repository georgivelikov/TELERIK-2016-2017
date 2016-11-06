using System;
using System.Linq;
using System.Net;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            var pathToUri = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var localPath = "../../rssFeed.xml";
            var donwloader = new WebClient();

            donwloader.DownloadFile(pathToUri, localPath);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(localPath);

            var json = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonObj = JObject.Parse(json);

            // Task 03
            var videoTitles = 
                from v in jsonObj["feed"]["entry"]
                select (string)v["title"];

            Console.WriteLine("Task 03:");
            foreach (var title in videoTitles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine(new string('-', 40));

            // Task 04:
            var videoEntries = jsonObj["feed"]["entry"]
                .Select(e => new Video()
                                 {
                                     Title = (string)e["title"],
                                     Author = (string)e["author"]["name"],
                                     Link = (string)e["link"]["@href"]
                                 });
            Console.WriteLine("Task 04:");
            foreach (var item in videoEntries)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
