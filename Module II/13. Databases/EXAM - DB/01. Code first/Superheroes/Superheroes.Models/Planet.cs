using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Superheroes.Models
{
    public class Planet
    {
        private ICollection<Country> countries;

        private ICollection<Fraction> fractions;

        public Planet()
        {
            this.countries = new HashSet<Country>();
            this.fractions = new HashSet<Fraction>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(30), MinLength(2)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }
            set
            {
                this.countries = value;
            }
        }

        public virtual ICollection<Fraction> Fractions
        {
            get
            {
                return this.fractions;
            }
            set
            {
                this.fractions = value;
            }
        }
    }
}
