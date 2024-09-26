using HAN.Weatherforecast.Service.Data.Configurations;
using HAN.Weatherforecast.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace HAN.Weatherforecast.Service.Data
{
    internal class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeatherForecastEntityTypeConfiguration).Assembly);
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    }
}
