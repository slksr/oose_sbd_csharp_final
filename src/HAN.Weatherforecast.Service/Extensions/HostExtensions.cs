using HAN.Weatherforecast.Service.Data.TestData;
using HAN.Weatherforecast.Service.Data;
using HAN.Weatherforecast.Service.Services;

namespace HAN.Weatherforecast.Service.Extensions
{
    internal static class HostExtensions
    {
        /// <summary>
        /// Seed example data in the database
        /// </summary>
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WeatherForecastDbContext>();
                var systemDate = services.GetRequiredService<ISystemDate>();

                // Always recreate database so we don't need migrations
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Seed test data
                new WeatherForecastSeeder(context, systemDate).SeedData();
            }

            return host;
        }
    }
}
