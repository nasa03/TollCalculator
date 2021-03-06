using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TollCalculator.API.Models
{
    public class VehicleType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public bool IsTollEligible { get; set; }

        public virtual ICollection<LicensePlate> LicensePlates { get; set; }
    }
}