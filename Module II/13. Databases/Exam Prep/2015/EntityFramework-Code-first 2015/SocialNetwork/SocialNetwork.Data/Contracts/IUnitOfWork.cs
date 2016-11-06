using System;

namespace SocialNetwork.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
