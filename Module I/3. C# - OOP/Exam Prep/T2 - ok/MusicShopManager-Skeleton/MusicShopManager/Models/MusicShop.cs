namespace MusicShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MusicShopManager.Interfaces;

    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles;

        public MusicShop(string name)
        {
            this.Name = name;
            this.articles = new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Must have");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get
            {
                return this.articles;
            }
        }

        public void AddArticle(IArticle article)
        {
            if (!this.articles.Any(a => a.Make == article.Make && a.Model == article.Model))
            {
                this.articles.Add(article);
            }
        }

        public void RemoveArticle(IArticle article)
        {
            if (this.articles.Any(a => a.Make == article.Make && a.Model == article.Model))
            {
                this.articles.Remove(article);
            }
        }

        public string ListArticles()
        {
            var microphones = this.articles.Where(a => a is Microphone).OrderBy(a => a.Make).ThenBy(a => a.Model).ToList();
            var drums = this.articles.Where(a => a is Drums).OrderBy(a => a.Make).ThenBy(a => a.Model).ToList();
            var baseGuitars = this.articles.Where(a => a is BaseGuitar).OrderBy(a => a.Make).ThenBy(a => a.Model).ToList();
            var electricGuitars = this.articles.Where(a => a is ElectricGuitar).OrderBy(a => a.Make).ThenBy(a => a.Model).ToList();
            var acousticGuitars = this.articles.Where(a => a is AcousticGuitar).OrderBy(a => a.Make).ThenBy(a => a.Model).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("===== {0} =====\n", this.Name);
            if (this.articles.Count == 0)
            {
                sb.AppendLine("The shop is empty. Come back soon.");
            }
            else
            {
                if (microphones.Count != 0)
                {
                    sb.AppendLine("----- Microphones -----");
                    foreach (var m in microphones)
                    {
                        sb.AppendLine(m.ToString());
                    }
                }

                if (drums.Count != 0)
                {
                    sb.AppendLine("----- Drums -----");
                    foreach (var d in drums)
                    {
                        sb.AppendLine(d.ToString());
                    }
                }

                if (electricGuitars.Count != 0)
                {
                    sb.AppendLine("----- Electric guitars -----");
                    foreach (var e in electricGuitars)
                    {
                        sb.AppendLine(e.ToString());
                    }
                }

                if (acousticGuitars.Count != 0)
                {
                    sb.AppendLine("----- Acoustic guitars -----");
                    foreach (var a in acousticGuitars)
                    {
                        sb.AppendLine(a.ToString());
                    }
                }

                if (baseGuitars.Count != 0)
                {
                    sb.AppendLine("----- Bass guitars -----");
                    foreach (var b in baseGuitars)
                    {
                        sb.AppendLine(b.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
