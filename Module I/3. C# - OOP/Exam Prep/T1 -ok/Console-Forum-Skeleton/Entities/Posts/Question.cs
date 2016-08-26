namespace ConsoleForum.Entities.Posts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Contracts;

    public class Question : Post, IQuestion
    {
        private List<IAnswer> answers = new List<IAnswer>();
        
        public Question(int id, string title, string body, IUser author)
            : base(id, body, author)
        {
            this.Title = title;
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers
        {
            get
            {
                return this.answers;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[ Question ID: {0} ]\n", this.Id);
            sb.AppendFormat("Posted by: {0}\n", this.Author.Username);
            sb.AppendFormat("Question Title: {0}\n", this.Title);
            sb.AppendFormat("Question Body: {0}\n", this.Body);
            sb.AppendFormat("====================\n");
            if (this.answers.Count == 0)
            {
                sb.AppendFormat("No answers\n");
            }
            else
            {
                sb.AppendFormat("Answers:\n");
                var bestAnswer = this.answers.Select(a => a as Answer).FirstOrDefault(a => a.BestAnswer);
                if (bestAnswer != null)
                {
                    sb.AppendLine(bestAnswer.ToString());
                }

                var sorted = this.answers.Select(a => a as Answer).OrderBy(a => a.Id);
                foreach (var answer in sorted)
                {
                    if (!answer.BestAnswer)
                    {
                        sb.AppendLine(answer.ToString());
                    }
                }
            }
            
            return sb.ToString().Trim();
        }
    }
}
