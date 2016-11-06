namespace NorthwindTwin
{
    using NorthwindTwin.NE;

    public class StartUp
    {
        public static void Main()
        {
            var db = new NorthwindEntities();

            db.Database.CreateIfNotExists();

            // see App.config - connection string changed to NothwindTwin, empty copy created
        }
    }
}
