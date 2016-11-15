using System.IO;

namespace Strategy
{
    public class FileWriter : IWriter
    {
        private static string path = "../../writer-output.txt";

        private StreamWriter writer = new StreamWriter(path);

        public void WriteLine(string line)
        {
            using (this.writer)
            {
                this.writer.WriteLine(line);
            }
        }
    }
}
