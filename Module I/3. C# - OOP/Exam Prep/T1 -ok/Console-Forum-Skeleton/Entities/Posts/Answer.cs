namespace ConsoleForum.Entities.Posts
{
    using System.Text;

    using ConsoleForum.Contracts;

    public class Answer : Post, IAnswer
    {
        private bool bestAnswer = false;

        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public bool BestAnswer
        {
            get
            {
                return this.bestAnswer;
            }

            set
            {
                this.bestAnswer = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            if (this.BestAnswer)
            {
                sb.AppendFormat("********************\n");
            }

            sb.AppendFormat("[ Answer ID: {0} ]\n", this.Id);
            sb.AppendFormat("Posted by: {0}\n", this.Author.Username);
            sb.AppendFormat("Answer Body: {0}\n", this.Body);
            sb.AppendFormat("--------------------\n");
            if (this.BestAnswer)
            {
                sb.AppendFormat("********************\n");
            }

            return sb.ToString().Trim();
        }
    }
}
