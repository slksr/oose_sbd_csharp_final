
using HAN.Weatherforecast.Service.Entities;
using HAN.Weatherforecast.Service.Services;

namespace HAN.Weatherforecast.Service.Data.TestData
{
    /// <summary>
    /// Creates weather forecast test data
    /// </summary>
    internal class WeatherForecastSeeder
    {
        private readonly WeatherForecastDbContext _context;
        private readonly ISystemDate _systemDate;

        public WeatherForecastSeeder(WeatherForecastDbContext context, ISystemDate systemDate)
        {
            _context = context;
            _systemDate = systemDate;
        }

        public void SeedData()
        {
            AddWeatherForecasts();

            _context.SaveChanges();
        }

        private void AddWeatherForecasts()
        {
            AddWeatherForecast(_systemDate.Today.AddDays(-1), WeatherType.Sunny, 12, 17, 0, 0, WindDirection.S, 0);
            AddWeatherForecast(_systemDate.Today, WeatherType.Sunny, 9, 12, 0, 1, WindDirection.S, 1);
            AddWeatherForecast(_systemDate.Today.AddDays(1), WeatherType.PartlyClouded, 5, 10, 0, 5, WindDirection.W, 1);
            AddWeatherForecast(_systemDate.Today.AddDays(2), WeatherType.Cloudy, 3, 9, 0.2m, 20, WindDirection.E, 1);
            AddWeatherForecast(_systemDate.Today.AddDays(3), WeatherType.Rainy, 2, 9, 12, 76, WindDirection.NW, 3);
            AddWeatherForecast(_systemDate.Today.AddDays(4), WeatherType.Stormy, -1, 2, 32, 90, WindDirection.W, 6);
            AddWeatherForecast(_systemDate.Today.AddDays(5), WeatherType.Snowy, -4, -1, 2, 22, WindDirection.N, 2);
            AddWeatherForecast(_systemDate.Today.AddDays(6), WeatherType.Snowy, -5, 0, 2, 22, WindDirection.N, 2);
        }

        private void AddWeatherForecast(DateTime date, WeatherType weatherType, int minimumTemperature, int maximumTemperature,
            decimal numberOfMillimetresRain, int percentageOfChanceOfRain, WindDirection windDirection, int windStrength)
        {
            var weatherForecastDoesNotExists = !_context.WeatherForecasts.Any(wf => wf.Date == date.Date);

            if (weatherForecastDoesNotExists)
            {
                _context.WeatherForecasts.Add(new WeatherForecast
                {
                    Date = date,
                    WeatherType = weatherType,
                    MinimumTemperature = minimumTemperature,
                    MaximumTemperature = maximumTemperature,
                    NumberOfMillimetresRain = numberOfMillimetresRain,
                    PercentageOfChanceOfRain = percentageOfChanceOfRain,
                    WindDirection = windDirection,
                    WindStrength = windStrength
                });
            }
        }
    }
}
