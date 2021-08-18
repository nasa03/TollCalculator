using Microsoft.EntityFrameworkCore;
using TollCalculator.API.Models;

namespace TollCalculator.API.Context
{
    internal class ApplicationDbContext : DbContext
    {
        internal ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        internal DbSet<TollEntry> TollEntries { get; set; }
    }
}