using HAN.Weatherforecast.Service.Entities;

namespace HAN.Weatherforecast.Service.Services
{
    public interface IWeatherForecastService
    {
        WeatherForecast GetByDate(DateTime date);
    }
}
