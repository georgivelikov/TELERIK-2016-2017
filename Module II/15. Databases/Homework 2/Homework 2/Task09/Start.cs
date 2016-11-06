using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Task09
{
    public class Start
    {
        public static void Main()
        {
            string startDirPath = @"../../";
            string[] subDirs = Directory.GetDirectories(startDirPath);
            string[] subFiles = Directory.GetFiles(startDirPath);

            string outputPath = "../../directories.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(outputPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 2;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

                foreach (var dir in subDirs)
                {
                    var dirName = ExtractName(dir);
                    writer.WriteElementString("dir", dirName);
                }

                foreach (var file in subFiles)
                {
                    var fileName = ExtractName(file);
                    writer.WriteElementString("file", fileName);
                }

                writer.WriteEndDocument();
            }
        }

        private static string ExtractName(string path)
        {
            var len = path.Length;
            var index = path.LastIndexOf("/", StringComparison.Ordinal);

            return path.Substring(index + 1, len - index - 1);
        }
    }
}
