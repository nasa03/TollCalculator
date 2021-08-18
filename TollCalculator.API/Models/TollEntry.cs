using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TollCalculator.API.Models
{
    public class TollEntry
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        public DateTime TimeOfEntry { get; set; }
        public double? Fee { get; set; }
    }
}