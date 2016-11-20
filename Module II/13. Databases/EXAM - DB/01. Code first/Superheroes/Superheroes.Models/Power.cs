using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Models
{
    public class Power
    {
        private ICollection<Superhero> superheros;

        public Power()
        {
            this.superheros = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(35), MinLength(3)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheros
        {
            get
            {
                return this.superheros;
            }
            set
            {
                this.superheros = value;
            }
        }
    }
}
