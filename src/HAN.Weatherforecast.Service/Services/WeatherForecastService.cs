using HAN.Weatherforecast.Service.Data.Repositories;
using HAN.Weatherforecast.Service.Entities;

namespace HAN.Weatherforecast.Service.Services
{
    internal class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public WeatherForecast GetByDate(DateTime date)
        {
            return _repository.GetByDate(date);
        }
    }
}
