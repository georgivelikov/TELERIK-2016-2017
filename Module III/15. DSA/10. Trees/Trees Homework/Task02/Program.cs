using System;
using System.IO;
using System.Text;

namespace Task02
{
    public class StartUp
    {
        private static StringBuilder output;

        private static void Main()
        {
            var directory = new DirectoryInfo(@"C:\Windows");

            output = new StringBuilder();

            TraverseDirectory(directory);

            Console.Write(output);
        }

        private static void TraverseDirectory(DirectoryInfo directory)
        {
            try
            {
                var files = directory.GetFiles();

                foreach (var file in files)
                {
                    if (file.Extension == ".exe")
                    {
                        output.AppendLine(file.Name);
                    }
                }

                var subDirectories = directory.GetDirectories();

                foreach (var subDirectory in subDirectories)
                {
                    TraverseDirectory(subDirectory);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
