namespace Task05
{
    public class Video
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Link { get; set; }

        public override string ToString()
        {
            return $"Title: {this.Title} by {this.Author}\nLink: {this.Link}";
        }
    }
}
