using SocialNetwork.Data;

using System.Collections;
using System.Linq;

using SocialNetwork.Data.Contracts;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Models.Models;

namespace SocialNetwork.ConsoleClient.Searcher
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private ISocialNetworkDataProvider db;

        public SocialNetworkService()
        {
            this.db = this.GenerateNewSocialNetworkDataProvider();
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            return
                this.db.Users.GetAll(
                    u => u.RegisteredOn.Year >= year,
                    u => u.Username,
                    u => new { u.Username, u.FirstName, u.LastName, Images = u.Images.Count }
                    )
                    .ToList();
            //return this.db.Users
            //    .Where(u => u.RegisteredOn.Year >= year)
            //    .Select(u => new
            //    {
            //        u.Username,
            //        u.FirstName,
            //        u.LastName,
            //        Images = u.Images.Count()
            //    })
            //    .ToList();
        }

        public IEnumerable GetPostsByUser(string username)
        {
            return this.db.Posts.All
                .Where(p => p.Users.Any(u => u.Username == username))
                .Select(p => new
                {
                    p.PostedOn,
                    p.Content,
                    Users = p.Users.Select(u => u.Username)
                })
                .ToList();
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var skip = (page - 1) * pageSize;
            var take = pageSize;

            return this.db.Friendships.All
                .Where(f => f.Approved)
                .OrderBy(f => f.FriendsSince)
                .Skip(skip)
                .Take(take)
                .Select(f => new
                {
                    FirstUserUsername = f.FirstUser.Username,
                    FirstUserImage = f.FirstUser.Images.Select(i => i.ImageUrl).FirstOrDefault(),
                    SecondUserUsername = f.SecondUser.Username,
                    SecondUserImage = f.SecondUser.Images.Select(i => i.ImageUrl).FirstOrDefault()
                })
                .ToList();
        }

        public IEnumerable GetChatUsers(string username)
        {
            return this.db.Messages.All
                .Where(m => m.Friendship.FirstUser.Username == username)
                .Select(m => m.Friendship.SecondUser.Username)
                .Union(
                    this.db.Messages.All
                    .Where(m => m.Friendship.SecondUser.Username == username)
                    .Select(m => m.Friendship.FirstUser.Username))
                .Where(u => u != username)
                .Distinct()
                .OrderBy(u => u)
                .ToList();
        }

        private ISocialNetworkDataProvider GenerateNewSocialNetworkDataProvider()
        {
            ISocialNetworkDbContext dbContext = new SocialNetworkDbContext();

            IUnitOfWork unitOfWork = new UnitOfWork(dbContext);

            IGenericRepository<User> users = new GenericRepository<User>(dbContext);
            IGenericRepository<Post> posts = new GenericRepository<Post>(dbContext);
            IGenericRepository<Message> messages = new GenericRepository<Message>(dbContext);
            IGenericRepository<Image> images = new GenericRepository<Image>(dbContext);
            IGenericRepository<Friendship> friendships = new GenericRepository<Friendship>(dbContext);

            return new SocialNetworkDataProvider(unitOfWork, users, posts, messages, images, friendships);
        }
    }
}
