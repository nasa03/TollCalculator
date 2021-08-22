using System.ComponentModel.DataAnnotations;

namespace TollCalculator.API.Models
{
    public class TollEntry
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime TimeOfEntry { get; set; }

        public double? Fee { get; set; }

        public virtual LicensePlate LicensePlate { get; set; }
    }
}