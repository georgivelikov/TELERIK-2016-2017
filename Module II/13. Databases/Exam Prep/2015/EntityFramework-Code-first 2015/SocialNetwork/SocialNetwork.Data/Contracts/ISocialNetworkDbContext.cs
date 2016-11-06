using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using SocialNetwork.Models.Models;

namespace SocialNetwork.Data.Contracts
{
    public interface ISocialNetworkDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Friendship> Friendships { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

    }
}
