using System;
using System.Linq;
using System.Net;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Task05
{
    using System.Xml.Xsl;

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

            var videoEntries = jsonObj["feed"]["entry"]
                .Select(e => new Video()
                {
                    Title = (string)e["title"],
                    Author = (string)e["author"]["name"],
                    Link = (string)e["link"]["@href"]
                });

            var pathToVideosXml = "../../videos.xml";
            var videosXml = new XmlDocument();
            videosXml.Load(pathToVideosXml);

            var videos = videosXml.DocumentElement;

            foreach (Video video in videoEntries)
            {
                var videoEl = videosXml.CreateElement("video");

                var titleEl = videosXml.CreateElement("title");
                titleEl.InnerText = video.Title;
                videoEl.AppendChild(titleEl);

                var authorEl = videosXml.CreateElement("author");
                authorEl.InnerText = video.Author;
                videoEl.AppendChild(authorEl);

                var linkEl = videosXml.CreateElement("link");
                linkEl.InnerText = video.Link;
                videoEl.AppendChild(linkEl);

                videos.AppendChild(videoEl);
            }

            videosXml.Save(pathToVideosXml);

            XslCompiledTransform xslt = new XslCompiledTransform();
            var xsltPath = "../../videos.xslt";
            var xmlPath = "../../videos.xml";
            var outputHtmlPath = "../../videos.html";
            xslt.Load(xsltPath);

            xslt.Transform(xmlPath, outputHtmlPath);
        }
    }
}
