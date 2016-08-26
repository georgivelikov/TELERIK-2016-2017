namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Band : Performer, IBand
    {
        private PerformerType type;
        private List<string> membersList;

        public Band(string name)
            : base(name)
        {
            this.type = PerformerType.Band;
            this.membersList = new List<string>();
        }

        public override PerformerType Type
        {
            get
            {
                return this.type;
            }
        }

        public IList<string> Members
        {
            get
            {
                return this.membersList;
            }
        }

        public void AddMember(string memberName)
        {
            this.membersList.Add(memberName);
        }

        public void AddSongTitle(ISong song)
        {
            this.Songs.Add(song);
        }

        public override string ToString()
        {
            var listOfSongs = this.Songs.ToList().Select(s => s.Title).ToList();
            listOfSongs.Sort();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "{0}: {1}\n",
                this.Name,
                this.membersList.Count == 0 ? string.Empty : string.Format("{0}", string.Join(", ", this.membersList)));
            sb.AppendFormat("{0}\n", listOfSongs.Count == 0 ? "no songs" : string.Join("; ", listOfSongs));

            return sb.ToString().Trim();
        }
    }
}
