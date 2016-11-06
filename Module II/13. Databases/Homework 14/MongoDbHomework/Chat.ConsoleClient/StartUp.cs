using System;
using System.Linq;

using Chat.Models;
using Chat.MongoDb;

using MongoDB.Driver;

namespace Chat.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            const string ConnectionString = "mongodb://georgivelikov:123456@ds063946.mlab.com:63946/telerik-homework";
            const string CollectionName = "Messages";
            const string DatabaseName = "telerik-homework";

            var db = GetDatabase(ConnectionString, DatabaseName);
            IRepository<Message> messagesRepository = new MongoDbRepository<Message>(db, CollectionName);
 
            var message2 = messagesRepository.All().Result.ToList().LastOrDefault();
            Console.WriteLine(message2.Id);
        }

        private static IMongoDatabase GetDatabase(string connectionString, string dataName)
        {
            var client = new MongoClient(connectionString);

            return client.GetDatabase(dataName);
        }
    }
}
