using SocialNetwork.Data.Contracts;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Models.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkDataProvider : ISocialNetworkDataProvider
    {
        private IUnitOfWork unitOfWork;

        public SocialNetworkDataProvider(
            IUnitOfWork unitOfWork, 
            IGenericRepository<User> users, 
            IGenericRepository<Post> posts, 
            IGenericRepository<Message> messages, 
            IGenericRepository<Image> images, 
            IGenericRepository<Friendship> friendships
            )
        {
            this.unitOfWork = unitOfWork;
            this.Users = users;
            this.Posts = posts;
            this.Messages = messages;
            this.Images = images;
            this.Friendships = friendships;
        }

        public IGenericRepository<User> Users { get; set; }

        public IGenericRepository<Post> Posts { get; set; }

        public IGenericRepository<Message> Messages { get; set; }

        public IGenericRepository<Image> Images { get; set; }

        public IGenericRepository<Friendship> Friendships { get; set; }

        public void Commit()
        {
            this.unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }
    }
}
