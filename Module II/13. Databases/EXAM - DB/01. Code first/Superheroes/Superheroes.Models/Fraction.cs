using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Superheroes.Models.Enums;

namespace Superheroes.Models
{
    public class Fraction
    {
        private ICollection<Superhero> superheroes;

        private ICollection<Planet> planets;
         
        public Fraction()
        {
            this.superheroes = new HashSet<Superhero>();
            this.planets = new HashSet<Planet>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(30), MinLength(2)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheroes
        {
            get
            {
                return this.superheroes;
            }
            set
            {
                this.superheroes = value;
            }
        }

        [Required]
        public AlignmentType Alignment { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get
            {
                return this.planets;
            }
            set
            {
                this.planets = value;
            }
        }
    }
}
