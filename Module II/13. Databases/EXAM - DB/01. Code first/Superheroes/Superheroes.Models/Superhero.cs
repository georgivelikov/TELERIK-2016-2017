using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Superheroes.Models.Enums;

namespace Superheroes.Models
{
    public class Superhero
    {
        private ICollection<Power> powers;

        private ICollection<Fraction> fractions;

        private ICollection<Relationship> relationships;

        public Superhero()
        {
            this.powers = new HashSet<Power>();
            this.fractions = new HashSet<Fraction>();
            this.relationships = new HashSet<Relationship>();
        } 

        public int Id { get; set; }

        [MaxLength(60), MinLength(3)]
        [Required]
        public string Name { get; set; }


        [Index(IsUnique = true)]
        [MaxLength(20), MinLength(3)]
        [Required]
        public string SecretIdentity { get; set; }

        [Required]
        public AlignmentType Alignment { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Story { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Power> Powers
        {
            get
            {
                return this.powers;
            }
            set
            {
                this.powers = value;
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

        public virtual ICollection<Relationship> Realationships
        {
            get
            {
                return this.relationships;
            }
            set
            {
                this.relationships = value;
            }
        }
    }
}
