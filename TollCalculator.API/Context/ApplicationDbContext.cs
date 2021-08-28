using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TollCalculator.API.Models;

namespace TollCalculator.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        internal DbSet<TollEntry> TollEntries { get; set; }
        internal DbSet<LicensePlate> LicensePlates { get; set; }
        internal DbSet<VehicleType> VehicleTypes { get; set; }

    }
}