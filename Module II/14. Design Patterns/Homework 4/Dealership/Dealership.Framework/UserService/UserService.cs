using System.Collections.Generic;
using System.Linq;

using Dealership.Contracts;
using Dealership.Framework.UserService;

namespace Dealership.Framework.UserService
{
    public class UserService : IUserService
    {
        private IList<IUser> users;

        public UserService()
        {
            this.users = new List<IUser>();
        }

        public IUser LoggedUser { get; private set; }

        public bool ContainsUser(string username)
        {
            var containsUser = this.users.Any(u => u.Username.ToLower() == username.ToLower());

            return containsUser;
        }

        public void DeleteAllUsers()
        {
            this.users = new List<IUser>();
            this.LoggedUser = null;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return new List<IUser>(this.users);
        }

        public IUser GetUser(string username)
        {
            var user = this.users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            return user;
        }

        public void LogIn(IUser user)
        {
            this.LoggedUser = user;
        }

        public void LogOut()
        {
            this.LoggedUser = null;
        }

        public void Register(IUser user)
        {
            this.users.Add(user);
        }
    }
}
