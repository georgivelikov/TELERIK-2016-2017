namespace MyTunesShop
{
    using System.Collections.Generic;
    using System.Text;

    public class Album : IAlbum
    {
        private string title;
        private decimal price;
        private IPerformer performer;
        private string genre;
        private int year;
        private List<ISong> listOfoSongs;
         
        public Album(string title, decimal price, IPerformer performer, string genre, int year)
        {
            this.title = title;
            this.price = price;
            this.performer = performer;
            this.genre = genre;
            this.year = year;
            this.listOfoSongs = new List<ISong>();
            this.SalesInfo = new SalesInfo();
        }

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        public IPerformer Performer
        {
            get
            {
                return this.performer;
            }
        }

        public string Genre
        {
            get
            {
                return this.genre;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
        }

        public IList<ISong> Songs
        {
            get
            {
                return this.listOfoSongs;
            }
        }

        public SalesInfo SalesInfo { get; set; }

        public void AddSong(ISong song)
        {
            this.listOfoSongs.Add(song);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} ({1}) by {2}\n", this.Title, this.Year, this.Performer);
            sb.AppendFormat("Genre: {0}, Price:${1}\n", this.Genre, this.Price);
            sb.AppendFormat("Supplies: {0}, Sold: {1}\n", this.SalesInfo.Supplies, this.SalesInfo.QuantitySold);
            if (this.listOfoSongs.Count == 0)
            {
                sb.AppendFormat("No Songs\n");
            }
            else
            {
                sb.AppendFormat("Songs:\n");
                foreach (var song in this.listOfoSongs)
                {
                    sb.AppendFormat("{0} ({1})\n", song.Title, song.Duration);
                }
            }

            return sb.ToString().Trim();
        }
    }
}
