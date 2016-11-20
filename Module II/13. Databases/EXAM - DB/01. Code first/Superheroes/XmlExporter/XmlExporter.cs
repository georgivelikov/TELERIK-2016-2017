using System.Collections.Generic;
using System.Linq;
using System.Xml;

using Superheroes.Data.Contracts;
using Superheroes.Models;

using XmlExporter.Contracts;

namespace XmlExporter
{
    public class XmlExporter : ISuperheroesUniverseExporter
    {
        private ISuperheroesDataProvider data;

        public XmlExporter(ISuperheroesDataProvider data)
        {
            this.data = data;
        }
        public string ExportAllSuperheroes()
        {
            var superheroes = this.data.Superheroes.GetAll();
            var doc = this.CreateXmlDocFromSuperheroes(superheroes);
            var savePath = "../../../../../03. Xml Files/ExportAllSuperheroes.xml";
            doc.Save(savePath);

            return doc.ToString();
        }

        public string ExportSupperheroesWithPower(string power)
        {
            var superheroes = this.data.Superheroes.GetAll().Where(s => s.Powers.Any(p => p.Name == power));
            var doc = this.CreateXmlDocFromSuperheroes(superheroes);
            var savePath = "../../../../../03. Xml Files/ExportSupperheroesWithPower.xml";
            doc.Save(savePath);

            return doc.ToString();
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            var superhero = this.data.Superheroes.GetAll().FirstOrDefault(s => s.Id == (int)superheroId);
            var doc = this.CreateXmlFromSuperhero(superhero);
            var savePath = "../../../../../03. Xml Files/ExportSuperheroDetails.xml";
            doc.Save(savePath);

            return doc.ToString();
        }

        public string ExportFractions()
        {
            var fractions = this.data.Fractions.GetAll();
            var doc = this.CreateXmlFromFractions(fractions);
            var savePath = "../../../../../03. Xml Files/ExportFractions.xml";
            doc.Save(savePath);

            return doc.ToString();
        }

        public string ExportFractionDetails(object fractionId)
        {
            var fraction = this.data.Fractions.GetAll().FirstOrDefault(f => f.Id == (int)fractionId);
            var doc = this.CreateXmlFromFraction(fraction);
            var savePath = "../../../../../03. Xml Files/ExportFractionDetails.xml";
            doc.Save(savePath);

            return doc.ToString();
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            var superheroes = this.data.Superheroes.GetAll().Where(s => s.City.Name == cityName);
            var doc = this.CreateXmlDocFromSuperheroes(superheroes);
            var savePath = "../../../../../03. Xml Files/ExportSuperheroesByCity.xml";
            doc.Save(savePath);

            return doc.ToString();
        }

        private XmlDocument CreateXmlDocFromSuperheroes(IEnumerable<Superhero> superheroes)
        {
            var doc = new XmlDocument();
            var superheroHolder = doc.CreateElement("superheroes");
            doc.AppendChild(superheroHolder);

            foreach (var superhero in superheroes)
            {
                var superheroEl = doc.CreateElement("superhero");
                superheroHolder.AppendChild(superheroEl);

                var idAttr = doc.CreateAttribute("id");
                idAttr.InnerText = superhero.Id.ToString();
                superheroEl.Attributes.Append(idAttr);

                var nameEl = doc.CreateElement("name");
                nameEl.InnerText = superhero.Name;
                superheroEl.AppendChild(nameEl);

                var secterIdentityEl = doc.CreateElement("secretIdentity");
                secterIdentityEl.InnerText = superhero.SecretIdentity;
                superheroEl.AppendChild(secterIdentityEl);

                var alignmentEl = doc.CreateElement("alignment");
                alignmentEl.InnerText = superhero.Alignment.ToString();
                superheroEl.AppendChild(alignmentEl);

                var powersEl = doc.CreateElement("powers");
                foreach (var power in superhero.Powers)
                {
                    var powerEl = doc.CreateElement("power");
                    powerEl.InnerText = power.Name;
                    powersEl.AppendChild(powerEl);
                }

                superheroEl.AppendChild(powersEl);

                var cityEl = doc.CreateElement("city");
                var cityInfo = new string[]
                                   {
                                       superhero.City.Name,
                                       superhero.City.Country.Name,
                                       superhero.City.Country.Planet.Name
                                   };

                cityEl.InnerText = string.Join(", ", cityInfo);
                superheroEl.AppendChild(cityEl);
            }

            return doc;
        }

        private XmlDocument CreateXmlFromFractions(IEnumerable<Fraction> fractions)
        {
            var doc = new XmlDocument();
            var fractionHolder = doc.CreateElement("fractions");
            doc.AppendChild(fractionHolder);

            foreach (var fraction in fractions)
            {
                var fractionEl = doc.CreateElement("fraction");
                fractionHolder.AppendChild(fractionEl);

                var fractionId = doc.CreateAttribute("id");
                fractionId.InnerText = fraction.Id.ToString();
                fractionEl.Attributes.Append(fractionId);

                var membersCount = doc.CreateAttribute("membersCount");
                membersCount.InnerText = fraction.Superheroes.Count.ToString();
                fractionEl.Attributes.Append(membersCount);

                var nameEl = doc.CreateElement("name");
                nameEl.InnerText = fraction.Name;
                fractionEl.AppendChild(nameEl);

                var planetsEl = doc.CreateElement("planets");
                foreach (var planet in fraction.Planets)
                {
                    var planetEl = doc.CreateElement("planet");
                    planetEl.InnerText = planet.Name;
                    planetsEl.AppendChild(planetEl);
                }

                fractionEl.AppendChild(planetsEl);
            }

            return doc;
        }

        private XmlDocument CreateXmlFromFraction(Fraction fraction)
        {
            var doc = new XmlDocument();
            var fractionEl = doc.CreateElement("fraction");
            doc.AppendChild(fractionEl);

            var fractionId = doc.CreateAttribute("id");
            fractionId.InnerText = fraction.Id.ToString();
            fractionEl.Attributes.Append(fractionId);

            var membersCount = doc.CreateAttribute("membersCount");
            membersCount.InnerText = fraction.Superheroes.Count.ToString();
            fractionEl.Attributes.Append(membersCount);

            var nameEl = doc.CreateElement("name");
            nameEl.InnerText = fraction.Name;
            fractionEl.AppendChild(nameEl);

            var planetsEl = doc.CreateElement("planets");
            foreach (var planet in fraction.Planets)
            {
                var planetEl = doc.CreateElement("planet");
                planetEl.InnerText = planet.Name;
                planetsEl.AppendChild(planetEl);
            }

            fractionEl.AppendChild(planetsEl);

            var membersEl = doc.CreateElement("members");
            foreach (var member in fraction.Superheroes)
            {
                var memberEl = doc.CreateElement("member");
                memberEl.InnerText = member.Name;
                membersEl.AppendChild(memberEl);
            }

            fractionEl.AppendChild(membersEl);

            return doc;
        }

        private XmlDocument CreateXmlFromSuperhero(Superhero superhero)
        {
            var doc = new XmlDocument();
            var superheroEl = doc.CreateElement("superhero");
            doc.AppendChild(superheroEl);

            var superheroId = doc.CreateAttribute("id");
            superheroId.InnerText = superhero.Id.ToString();
            superheroEl.Attributes.Append(superheroId);

            var nameEl = doc.CreateElement("name");
            nameEl.InnerText = superhero.Name;
            superheroEl.AppendChild(nameEl);

            var secterIdentityEl = doc.CreateElement("secretIdentity");
            secterIdentityEl.InnerText = superhero.SecretIdentity;
            superheroEl.AppendChild(secterIdentityEl);

            var alignmentEl = doc.CreateElement("alignment");
            alignmentEl.InnerText = superhero.Alignment.ToString();
            superheroEl.AppendChild(alignmentEl);

            var powersEl = doc.CreateElement("powers");
            foreach (var power in superhero.Powers)
            {
                var powerEl = doc.CreateElement("power");
                powerEl.InnerText = power.Name;
                powersEl.AppendChild(powerEl);
            }

            superheroEl.AppendChild(powersEl);

            var fractionsEl = doc.CreateElement("fractions");
            foreach (var fr in superhero.Fractions)
            {
                var frEl = doc.CreateElement("fraction");
                frEl.InnerText = fr.Name;
                fractionsEl.AppendChild(frEl);
            }

            superheroEl.AppendChild(fractionsEl);

            var cityEl = doc.CreateElement("city");
            var cityInfo = new string[]
                               {
                                       superhero.City.Name,
                                       superhero.City.Country.Name,
                                       superhero.City.Country.Planet.Name
                               };

            cityEl.InnerText = string.Join(", ", cityInfo);
            superheroEl.AppendChild(cityEl);

            var storyEl = doc.CreateElement("story");
            storyEl.InnerText = superhero.Story;
            superheroEl.AppendChild(storyEl);

            return doc;
        }
    }
}
