using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using SocialNetwork.ConsoleClient.Searcher;
using SocialNetwork.ConsoleClient.XmlModels;
using SocialNetwork.Data;
using SocialNetwork.Data.Contracts;
using SocialNetwork.Data.Migrations;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Models.Models;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        private static ISocialNetworkDataProvider database = GenerateNewSocialNetworkDataProvider();

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            SeedFriendships();

            SeedPosts();

            var searcher = new SocialNetworkService();
            Searcher.Searcher.Search(searcher);
        }

        private static void SeedFriendships()
        {
            if (database.Friendships.GetAll().Any())
            {
                return;
            }
            var path = "XmlFiles/Friendships.xml";
            var serializer = new XmlSerializer(typeof(List<XmlFriendship>), new XmlRootAttribute("Friendships"));
            var reader = new FileStream(path, FileMode.Open);

            List<XmlFriendship> resultCollection;

            using (reader)
            {
                resultCollection = (List<XmlFriendship>)serializer.Deserialize(reader);
            }

            var friendshipCounter = 0;

            foreach (var res in resultCollection)
            {
                var friendship = new Friendship() { Approved = res.Approved, FriendsSince = res.FriendsSince };

                var firstUsername = res.FirstUser.Username;

                var firstUser = database.Users.GetAll().FirstOrDefault(u => u.Username == firstUsername);

                if (firstUser == null)
                {
                    firstUser = new User()
                                    {
                                        Username = firstUsername,
                                        FirstName = res.FirstUser.FirstName,
                                        LastName = res.FirstUser.LastName,
                                        RegisteredOn = res.FirstUser.RegisteredOn
                                    };
                }

                friendship.FirstUser = firstUser;

                var secondUsername = res.SecondUser.Username;
                var secondUser = database.Users.GetAll().FirstOrDefault(u => u.Username == secondUsername);

                if (secondUser == null)
                {
                    secondUser = new User()
                                     {
                                         Username = secondUsername,
                                         FirstName = res.SecondUser.FirstName,
                                         LastName = res.SecondUser.LastName,
                                         RegisteredOn = res.SecondUser.RegisteredOn
                                     };
                }

                friendship.SecondUser = secondUser;

                foreach (var xmlMessage in res.Messages)
                {
                    var message = new Message()
                                      {
                                          Content = xmlMessage.Content,
                                          Author = xmlMessage.Author == firstUsername ? firstUser : secondUser,
                                          SentOn = xmlMessage.SentOn,
                                          SeenOn = xmlMessage.SeenOn
                                      };

                    friendship.Messages.Add(message);
                }

                foreach (var img in res.FirstUser.Images)
                {
                    var image = new Image() { ImageUrl = img.ImageUrl, FileExtension = img.FileExtension };

                    friendship.FirstUser.Images.Add(image);
                }

                foreach (var img in res.SecondUser.Images)
                {
                    var image = new Image() { ImageUrl = img.ImageUrl, FileExtension = img.FileExtension };

                    friendship.SecondUser.Images.Add(image);
                }

                database.Friendships.Add(friendship);
                friendshipCounter++;
                database.Commit();

                if (friendshipCounter % 100 == 0)
                {
                    database = GenerateNewSocialNetworkDataProvider();
                }
            }
        }

        private static void SeedPosts()
        {
            if (database.Posts.GetAll().Any())
            {
                return;
            }

            var path = "XmlFiles/Posts.xml";
            var serializer = new XmlSerializer(typeof(List<XmlPost>), new XmlRootAttribute("Posts"));
            var reader = new FileStream(path, FileMode.Open);

            List<XmlPost> resultCollection;

            using (reader)
            {
                resultCollection = (List<XmlPost>)serializer.Deserialize(reader);
            }

            int postCounter = 0;

            foreach (var res in resultCollection)
            {
                var usernames = res.Users.Split(',');
                var users = new List<User>();
                foreach (var username in usernames)
                {
                    var user = database.Users.GetAll().FirstOrDefault(u => u.Username == username);
                    users.Add(user);
                }
                
                var post = new Post() { PostedOn = res.PostedOn, Content = res.Content, Users = users };
                database.Posts.Add(post);

                if (postCounter % 100 == 0)
                {
                    database.Commit();
                    database = GenerateNewSocialNetworkDataProvider();
                }
            }

            database.Commit();
        }

        private static ISocialNetworkDataProvider GenerateNewSocialNetworkDataProvider()
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
