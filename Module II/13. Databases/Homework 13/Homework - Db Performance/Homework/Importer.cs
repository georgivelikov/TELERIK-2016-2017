using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Company.DataGenerator;

using Homework.Models;

namespace Homework
{
    public class Importer
    {
        private DbPerformanceHomeworkContext db;

        public Importer(DbPerformanceHomeworkContext db)
        {
            this.db = db;
        }

        public void Import(int count)
        {
            var counter = 0;

            for (int i = 0; i < count; i++)
            {
                this.ImportEntry();
                counter++;

                if (counter == 100)
                {
                    counter = 0;
                    this.db.SaveChanges();
                }
            }

            this.db.SaveChanges();
        }

        private void ImportEntry()
        {
            var entry = this.GenerateEntry();

            this.db.Entries.Add(entry);
        }

        private Entry GenerateEntry()
        {
            var date = RandomGenerator.Instance.GetRandomDate();
            var text = RandomGenerator.Instance.GetRandomString(10);

            var entry = new Entry() { Text = text, Date = date };

            return entry;
        }
    }
}
