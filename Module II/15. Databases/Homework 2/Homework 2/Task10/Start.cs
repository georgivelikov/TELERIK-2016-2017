using System;
using System.IO;
using System.Xml.Linq;

namespace Task10
{
    public class Start
    {
        public static void Main()
        {
            string dirPath = "../../";
            string path = "../../directories.xml";
            string[] subDirs = Directory.GetDirectories(dirPath);
            string[] subFiles = Directory.GetFiles(dirPath);

            var xDoc = XDocument.Load(path);

            foreach (var dir in subDirs)
            {
                var dirName = ExtractName(dir);
                var dirElement = new XElement("dir");
                dirElement.SetValue(dirName);
                dirElement.Value = dirName;
                xDoc.Root.Add(dirElement);
            }

            foreach (var file in subFiles)
            {
                var fileName = ExtractName(file);
                var fileElement = new XElement("file");
                fileElement.Value = fileName;
                xDoc.Root.Add(fileElement);
            }

            xDoc.Save(path);
        }

        private static string ExtractName(string path)
        {
            var len = path.Length;
            var index = path.LastIndexOf("/", StringComparison.Ordinal);

            return path.Substring(index + 1, len - index - 1);
        }
    }
}
