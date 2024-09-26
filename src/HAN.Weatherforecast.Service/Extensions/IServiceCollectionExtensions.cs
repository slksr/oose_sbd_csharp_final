using HAN.Weatherforecast.Service.Data;
using HAN.Weatherforecast.Service.Data.Repositories;
using HAN.Weatherforecast.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace HAN.Weatherforecast.Service.Extensions
{
    /// <summary>
    /// Contains helper methods to configure the <see cref="IServiceCollection"/>
    /// </summary>
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherForecastDependencies(this IServiceCollection services)
        {
            return services
                .AddTransient<IWeatherForecastRepository, WeatherForecastRepository>()
                .AddTransient<IWeatherForecastService, WeatherForecastService>()
                .AddSingleton<ISystemDate, SystemDate>();
        }

        /// <remarks>
        /// Adding the <see cref="WeatherForecastDbContext"/> is separated from the other dependencies,
        /// so we can register a different database type for test automation (e.g. in memory)
        /// </remarks>
        public static IServiceCollection AddWeatherForecastDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<WeatherForecastDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:WeatherForecastDatabase"));
        }

        public static IServiceCollection EnsureDatabaseExists(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetRequiredService<WeatherForecastDbContext>();
            context.Database.EnsureCreated();

            return services;
        }
    }
}
