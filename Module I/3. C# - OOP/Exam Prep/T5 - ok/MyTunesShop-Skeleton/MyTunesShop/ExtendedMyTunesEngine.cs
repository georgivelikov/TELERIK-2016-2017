namespace MyTunesShop
{
    using System;
    using System.Linq;
    using System.Text;

    public class ExtendedMyTunesEngine : MyTunesEngine
    {
        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            var song = this.media.FirstOrDefault(s => s.Title == commandWords[2]);

            if (song != null)
            {
                var rateableSong = (Song)song;
                rateableSong.PlaceRating(int.Parse(commandWords[3]));
                this.Printer.PrintLine("The rating has been placed successfully.");
            }
            else
            {
                this.Printer.PrintLine("The song does not exist in the database.");
            }
        }

        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    this.ExecuteInsertSongToAlbum(commandWords);
                    break;
                case "member_to_band":
                    this.ExecuteInsertMemberToBand(commandWords);
                    break;
                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    var album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }


        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetSongReport(song));
                    break;
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(p => p is Band && p.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            string rating = "0";
            if (song.Ratings.Count != 0)
            {
                double sum = 0;
                for (int i = 0; i < song.Ratings.Count; i++)
                {
                    sum += song.Ratings[i];
                }

                sum /= song.Ratings.Count;
                sum = Math.Round(sum, MidpointRounding.AwayFromZero);
                rating = string.Empty + sum;
            }

            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
                .AppendFormat("Rating: {0}", rating).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString().Trim();
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }

        private string GetAlbumReport(IAlbum album)
        {
            var albumSalesInfo = this.mediaSupplies[album];
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} ({1}) by {2}\n", album.Title, album.Year, album.Performer.Name);
            sb.AppendFormat("Genre: {0}, Price: ${1}\n", album.Genre, album.Price);
            sb.AppendFormat("Supplies: {0}, Sold: {1}\n", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold);
            if (album.Songs.Count == 0)
            {
                sb.AppendFormat("No songs\n");
            }
            else
            {
                sb.AppendFormat("Songs:\n");
                foreach (var song in album.Songs)
                {
                    sb.AppendFormat("{0} ({1})\n", song.Title, song.Duration);
                }
            }

            return sb.ToString().Trim();
        }

        private string GetBandReport(Band band)
        {

            return band.ToString().Trim();
        }

        private void InsertAlbum(IAlbum album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        private void ExecuteInsertSongToAlbum(string[] commandWords)
        {
            var album = this.media.FirstOrDefault(a => a.Title == commandWords[2]) as Album;
            if (album == null)
            {
                this.Printer.PrintLine("The album does not exist in the database.");
                return;
            }

            var song = this.media.FirstOrDefault(s => s.Title == commandWords[3]);
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }

            album.AddSong((Song)song);
            //if (album.Performer is Band)
            //{
            //    var performers = album.Performer as Band;
            //    performers.AddSongTitle((Song)song);
            //}

            this.Printer.PrintLine(string.Format("The song {0} has been added to the album {1}.", song.Title, album.Title));
        }

        private void ExecuteInsertMemberToBand(string[] commandWords)
        {
            var band = this.performers.FirstOrDefault(b => b.Name == commandWords[2]);
            if (band == null)
            {
                this.Printer.PrintLine("The band does not exist in the database.");
            }
            var newBand = (Band)band;
            newBand.AddMember(commandWords[3]);
            this.Printer.PrintLine(string.Format("The member {0} has been added to the band {1}.", commandWords[3], newBand.Name));
        }
    }
}
