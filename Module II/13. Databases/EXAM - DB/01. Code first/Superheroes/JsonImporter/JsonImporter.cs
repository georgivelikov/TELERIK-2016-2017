using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JsonImporter.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Superheroes.Data.Contracts;
using Superheroes.Models;
using Superheroes.Models.Enums;

namespace JsonImporter
{
    public class JsonImporter
    {

        public void Import(ISuperheroesDataProvider data)
        {
            if (data.Superheroes.GetAll().Any())
            {
                return;
            }

            var jsonFile = File.ReadAllText("../../../../../02. Json-Data/sample-data.json");
            JObject jObj = JObject.Parse(jsonFile);
            var superheroCollection = new List<JsonSuperhero>();
            foreach (var obj in jObj["data"])
            {
                var superhero = JsonConvert.DeserializeObject<JsonSuperhero>(obj.ToString());
                superheroCollection.Add(superhero);
            }
            
            foreach (var obj in superheroCollection)
            {
                var planet = data.Planets.GetAll().FirstOrDefault(p => p.Name == obj.City.Planet);

                if (planet == null)
                {
                    planet = new Planet() { Name = obj.City.Planet };
                }

                var country = data.Countries.GetAll().FirstOrDefault(c => c.Name == obj.City.Country);

                if (country == null)
                {
                    country = new Country() { Name = obj.City.Country, Planet = planet };
                }

                var city = data.Cities.GetAll().FirstOrDefault(c => c.Name == obj.City.Name);

                if (city == null)
                {
                    city = new City() { Name = obj.City.Name, Country = country };
                }

                var superheroName = obj.Name;

                var secretIdentity = obj.SecretIdentity;

                var story = obj.Story;

                var alignement = (AlignmentType)Enum.Parse(typeof(AlignmentType), obj.Alignment.ToUpper());

                var powers = obj.Powers;
                var currentPowers = new List<Power>();
                foreach (var powerName in powers)
                {
                    var power = data.Powers.GetAll().FirstOrDefault(p => p.Name == powerName);
                    if (power == null)
                    {
                        power = new Power() { Name = powerName };
                    }

                    currentPowers.Add(power);
                }

                var fractions = obj.Fractions;
                var currentFractions = new List<Fraction>();
                if (fractions != null)
                {
                    foreach (var fractionName in fractions)
                    {
                        var fraction = data.Fractions.GetAll().FirstOrDefault(f => f.Name == fractionName);

                        if (fraction == null)
                        {
                            fraction = new Fraction() { Name = fractionName, Alignment = alignement };
                            fraction.Planets.Add(planet);
                            planet.Fractions.Add(fraction);
                        }

                        currentFractions.Add(fraction);
                    }
                }

                var superhero = new Superhero()
                                    {
                                        Name = superheroName,
                                        SecretIdentity = secretIdentity,
                                        Alignment = alignement,
                                        City = city,
                                        Story = story,
                                        Powers = currentPowers,
                                        Fractions = currentFractions
                                    };
                foreach (var power in currentPowers)
                {
                    power.Superheros.Add(superhero);
                }

                foreach (var fraction in currentFractions)
                {
                    fraction.Superheroes.Add(superhero);
                }

                data.Superheroes.Add(superhero);
                data.Commit();
            }
        }
    }
        
}

