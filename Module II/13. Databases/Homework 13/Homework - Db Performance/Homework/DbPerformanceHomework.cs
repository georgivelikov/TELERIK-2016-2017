using System.Data.Entity;

using Homework.Models;

namespace Homework
{
    public class DbPerformanceHomeworkContext : DbContext
    {
        public DbPerformanceHomeworkContext()
            :base("DbPerformanceHomework")
        {
            
        }

        public DbSet<Entry> Entries { get; set; }
    }
}
