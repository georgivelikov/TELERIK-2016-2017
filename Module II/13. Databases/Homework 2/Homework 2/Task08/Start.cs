namespace Task08
{
    using System.Text;
    using System.Xml;

    public class Start
    {
        public static void Main()
        {
            string fileName = "../../albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
                {
                    var title = string.Empty;
                    var author = string.Empty;
                    while (reader.Read())
                    {
                        if(reader.Name == "name")
                        {
                            title = reader.ReadInnerXml().Trim();
                        }
                        if (reader.Name == "artist")
                        {
                            author = reader.ReadInnerXml().Trim();
                            WriteAlbum(writer, title, author);
                        }
                    }
                }
                
                writer.WriteEndDocument();
            }
        }

        private static void WriteAlbum(XmlWriter writer, string title, string author)
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("title", title);
            writer.WriteElementString("author", author);
            writer.WriteEndElement();
        }
    }
}
