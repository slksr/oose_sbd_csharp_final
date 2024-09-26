using HAN.Weatherforecast.Service.Entities;

namespace HAN.Weatherforecast.Service.Data.Repositories
{
    internal class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastDbContext _context;

        public WeatherForecastRepository(WeatherForecastDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public WeatherForecast GetByDate(DateTime date)
        {
            return _context.WeatherForecasts.Single(wf => wf.Date == date);
        }
    }
}
