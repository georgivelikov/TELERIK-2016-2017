using Superheroes.Data.Contracts;

namespace Superheroes.Data.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISuperheroesDbContext db;

        public UnitOfWork(ISuperheroesDbContext db)
        {
            this.db = db;
        }
        public void Dispose()
        {
            this.db.Dispose();
        }

        public void SaveChanges()
        {
            this.db.SaveChanges();
        }
    }
}
