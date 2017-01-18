using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.SubFolders = new HashSet<Folder>();
            this.Files = new HashSet<File>();
        }

        public string Name { get; private set; }

        public ICollection<Folder> SubFolders { get; set; }

        public ICollection<File> Files { get; set; }

        public long CalculateFilesSize()
        {
            return this.Files.Sum(f => f.Size) / 1024;
        }
    }
}
