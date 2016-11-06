using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace Task11
{
    public class Start
    {
        private static void Main()
        {
            string path = "../../../catalog.xml";
            var doc = XDocument.Load(path);
            
            var albums = from album in doc.Descendants("album")
                         where int.Parse(album.Element("year").Value) > 2011
                         select album.Element("name").Value;


            foreach (var name in albums)
            {
                Console.WriteLine(name.Trim());
            }
        }
    }
}


