using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TollCalculator.API.Models
{
    internal class TollEntry
    {
        [Required]
        internal Guid Id { get; set; }
        [Required]
        internal string LicensePlate { get; set; }
        [Required]
        internal DateTime TimeOfEntry { get; set; }
        [Required]
        internal double Fee { get; set; }
    }
}