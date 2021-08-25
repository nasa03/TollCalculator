using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TollCalculator.API.Models
{
    public class VehicleType
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public bool IsTollEligable { get; set; }

        public virtual ICollection<LicensePlate> LicensePlates { get; set; }
    }
}