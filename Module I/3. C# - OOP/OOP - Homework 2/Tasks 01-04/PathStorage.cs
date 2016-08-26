namespace Tasks_01_04
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        public static void SavePath(string saveDestinationPath, Path path)
        {
            StreamWriter writer = new StreamWriter(saveDestinationPath); 
            using (writer)
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine(point);
                }
            }
        }

        public static Path LoatPath(string loadSourcePath)
        {
            Path path = new Path();
            StreamReader reader = new StreamReader(loadSourcePath);
            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    double[] input =
                        line.Split(new char[] { ',', ' ', ']', '[' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => double.Parse(x))
                            .ToArray();
                    Point p = new Point(input[0], input[1], input[2]);
                    path.AddPoint(p);
                }
            }

            return path;
        }
    }
}
