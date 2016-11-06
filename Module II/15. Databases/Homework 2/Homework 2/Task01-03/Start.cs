using System;
using System.Collections.Generic;
using System.Xml;

namespace Task01_03
{
    public class Start
    {
        public static void Main()
        {
            // Task 02
            var path = "../../../catalog.xml";
            var domDocument = new XmlDocument();
            domDocument.Load(path);

            XmlNode rootNode = domDocument.DocumentElement;
            var albumHolder = new Dictionary<string, int>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentAuthor = node["artist"].InnerText.Trim();
                if (!albumHolder.ContainsKey(currentAuthor))
                {
                    albumHolder.Add(currentAuthor, 0);
                }

                albumHolder[currentAuthor]++;
            }

            Console.WriteLine("Task 02:");
            foreach (var album in albumHolder)
            {
                Console.WriteLine($"Artist: {album.Key} - Albums count: {album.Value}");
            }
            Console.WriteLine(new string('-', 40));

            // Task 03
            string xPathQuery = "/catalog/album/artist[@type='artistName']";
            XmlNodeList list = domDocument.SelectNodes(xPathQuery);
            var albumHolderXpath = new Dictionary<string, int>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentAuthor = node["artist"].InnerText.Trim();
                if (!albumHolderXpath.ContainsKey(currentAuthor))
                {
                    albumHolderXpath.Add(currentAuthor, 0);
                }

                albumHolderXpath[currentAuthor]++;
            }
            Console.WriteLine("Task 03:");
            foreach (var album in albumHolderXpath)
            {
                Console.WriteLine($"Artist: {album.Key} - Albums count: {album.Value}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
