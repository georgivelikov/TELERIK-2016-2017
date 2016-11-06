using SocialNetwork.Data.Contracts;

namespace SocialNetwork.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISocialNetworkDbContext db;

        public UnitOfWork(ISocialNetworkDbContext db)
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
