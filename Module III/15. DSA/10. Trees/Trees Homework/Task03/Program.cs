using System;
using System.Collections.Generic;
using System.IO;

namespace Task03
{
    public class Program
    {
        private static ICollection<Folder> tree;
        private static long result = 0;

        private static void Main()
        {
            var start = new DirectoryInfo(@"C:\Windows");
            tree = new HashSet<Folder>();

            TraverseDirectory(start);

            Console.WriteLine((result / (1024 * 1024) + "GB"));
        }

        private static void TraverseDirectory(DirectoryInfo dir)
        {
            try
            {
                var fileInfos = dir.GetFiles();
                var folderInfos = dir.GetDirectories();
                var files = new HashSet<File>();
                var subFolders = new HashSet<Folder>();
                var currentFolder = new Folder(dir.Name);

                foreach (var file in fileInfos)
                {
                    files.Add(new File(file.Name, file.Length));
                }

                foreach (var childFolder in folderInfos)
                {
                    subFolders.Add(new Folder(childFolder.Name));
                }

                currentFolder.Files = files;
                currentFolder.SubFolders = subFolders;
                tree.Add(currentFolder);
                result += currentFolder.CalculateFilesSize();

                foreach (var subFolder in folderInfos)
                {
                    TraverseDirectory(subFolder);
                }
            }
            catch { }
        }
    }
}
