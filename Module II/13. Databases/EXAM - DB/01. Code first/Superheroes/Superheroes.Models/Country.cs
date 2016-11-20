using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Models
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
           this.cities = new HashSet<City>(); 
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(30), MinLength(2)]
        [Required]
        public string Name { get; set; }

        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}
