using System.Configuration;
using GetClimateAeC.Shared;
using Microsoft.EntityFrameworkCore;

namespace GetClimateAeC.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetClimateTables();
        }

        public DbSet<City> City { get; set; }
        public DbSet<CityClimate> CityClimate { get; set; }
        public DbSet<CityClimateArray> CityClimateArray { get; set; }
        public DbSet<AirportClimate> AirportClimate { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<AirportCodes> AirportCodes { get; set; }



    }

    public static class ClimateExtension
    {
        public static ModelBuilder SetClimateTables(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<CityClimate>().ToTable("CityClimate");
            modelBuilder.Entity<CityClimateArray>().ToTable("CityClimateArray");
            modelBuilder.Entity<AirportClimate>().ToTable("AirportClimate");
            modelBuilder.Entity<ErrorLog>().ToTable("ErrorLog");
            modelBuilder.Entity<AirportCodes>().ToTable("AirportCodes");
            
            return modelBuilder;
        }
    }

}
