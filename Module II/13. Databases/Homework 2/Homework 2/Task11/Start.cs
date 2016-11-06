using System;
using System.Xml;

namespace Task11
{
    public class Start
    {
        private static void Main()
        {
            string path = "../../../catalog.xml";
            XmlDocument doc = new XmlDocument();
            string xPathQuery = "catalog/album/year[text() > 2011]";

            doc.Load(path);

            XmlNodeList albums = doc.SelectNodes(xPathQuery);

            foreach (XmlNode album in albums)
            {
                var name = album.ParentNode.SelectSingleNode("name").InnerText.Trim();
                Console.WriteLine($"{name}, year {album.InnerText.Trim()}");

            }
        }
    }
}

