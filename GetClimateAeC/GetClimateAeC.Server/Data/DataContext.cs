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
        
        public DbSet<City> City { get; set; }
        public DbSet<CityClimate> CityClimate { get; set; }
        public DbSet<CityClimateArray> CityClimateArray { get; set; }
        public DbSet<AirportClimate> AirportClimate { get; set;}
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<AirportCodes> AirportCodes { get; set; }
    }
}
