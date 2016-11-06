using System;

using SocialNetwork.Data.Repositories;
using SocialNetwork.Models.Models;

namespace SocialNetwork.Data.Contracts
{
    public interface ISocialNetworkDataProvider : IDisposable
    {
        IGenericRepository<User> Users { get; set; }

        IGenericRepository<Post> Posts { get; set; }

        IGenericRepository<Message> Messages { get; set; }

        IGenericRepository<Image> Images { get; set; }

        IGenericRepository<Friendship> Friendships { get; set; }

        void Commit();
    }
}
