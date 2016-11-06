using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using SocialNetwork.Data.Contracts;
using SocialNetwork.Data.Migrations;
using SocialNetwork.Models.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkDbContext : DbContext, ISocialNetworkDbContext
    {
        public SocialNetworkDbContext()
            :base("SocialNetworkDb")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Friendship> Friendships { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
