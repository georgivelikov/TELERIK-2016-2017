using System;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Homework.Migrations;

namespace Homework
{
    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbPerformanceHomeworkContext, Configuration>());

            var db = new DbPerformanceHomeworkContext();
            //db.Configuration.AutoDetectChangesEnabled = false;
            //var importer = new Importer(db);

            // this will take a while
            //importer.Import(10000000);

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //SearchByDate(db, new DateTime(2005, 1, 1), new DateTime(2006, 1, 1));
            //sw.Stop();
            //Console.WriteLine("Elapased time for around 1 mil entries without index: " + sw.Elapsed);
        }

        //private static int SearchByDate(DbPerformanceHomeworkContext db, DateTime start, DateTime end)
        //{
        //    return db.Entries.Where(d => d.Date.Year >= start.Year && d.Date.Year <= end.Year).Count();
        //}
    }
}
