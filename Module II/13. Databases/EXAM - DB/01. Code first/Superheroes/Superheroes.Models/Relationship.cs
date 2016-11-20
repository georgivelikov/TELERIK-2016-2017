using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Superheroes.Models.Enums;

namespace Superheroes.Models
{
    public class Relationship
    {
        public int Id { get; set; }

        public int FirstSuperheroId { get; set; }

        public virtual Superhero FirstSuperhero { get; set; }

        public int SecondSuperheroId { get; set; }

        public virtual Superhero SecondSuperhero { get; set; }

        public RelationshipType RelationshipType { get; set; }
    }
}
