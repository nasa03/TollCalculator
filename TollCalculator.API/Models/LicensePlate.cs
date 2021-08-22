using System.ComponentModel.DataAnnotations;

namespace TollCalculator.API.Models
{
    public class LicensePlate
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public virtual ICollection<TollEntry> TollEntries { get; set; }
    }
}