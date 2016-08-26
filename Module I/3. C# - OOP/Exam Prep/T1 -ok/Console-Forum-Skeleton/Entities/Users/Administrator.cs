namespace ConsoleForum.Entities.Users
{
    public class Administrator : User
    {
        public Administrator(int id, string name, string password, string email)
            : base(id, name, password, email)
        {
        }
    }
}
