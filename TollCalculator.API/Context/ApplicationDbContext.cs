using Microsoft.EntityFrameworkCore;
using TollCalculator.API.Models;

namespace TollCalculator.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration
            .GetSection("ConnectionString")
            .Value;
            optionsBuilder.UseSqlite(connectionString);
        }

        internal DbSet<TollEntry> TollEntries { get; set; }
    }
}