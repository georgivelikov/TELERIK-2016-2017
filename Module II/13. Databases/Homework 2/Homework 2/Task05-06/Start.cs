using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace Task05_06
{
    public class Start
    {
        public static void Main()
        {
            // Task 05:
            var path = "../../../catalog.xml";
            var songTitles = new List<string>();
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        songTitles.Add(reader.ReadInnerXml().Trim());
                    }
                }
            }
            Console.WriteLine("Task05:");
            Console.WriteLine(string.Join("\n", songTitles));
            Console.WriteLine(new string('-', 40));
            // Task 06:
            var xDoc = XDocument.Load(path);
            var newSongTitles = from album in xDoc.Descendants("album")
                                from song in album.Descendants("song")
                                select song.Element("title").Value.Trim();

            Console.WriteLine("Task06:");
            Console.WriteLine(string.Join("\n", newSongTitles));
            Console.WriteLine(new string('-', 40));
        }
    }
}
