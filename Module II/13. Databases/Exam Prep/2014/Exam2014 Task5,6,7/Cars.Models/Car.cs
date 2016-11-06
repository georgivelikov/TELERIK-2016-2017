using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(25)]
        [Required]
        public string Model { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public decimal Price { get; set; }

        public int Year { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
