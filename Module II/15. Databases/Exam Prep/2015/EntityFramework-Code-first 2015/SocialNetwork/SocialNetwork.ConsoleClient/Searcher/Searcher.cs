using System;

namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class Searcher
    {
        public static void Search(ISocialNetworkService searcher)
        {
            var users = searcher.GetUsersAfterCertainDate(2013);
            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            var friendships = searcher.GetFriendships(2, 10);
            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            string filePath = "../../JsonResults/users.json";
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, json);
        }
    }
}
