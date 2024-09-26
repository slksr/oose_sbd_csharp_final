using HAN.Weatherforecast.Shared.Models;
using Refit;

namespace HAN.Weatherforecast.Website.Services
{
    [Headers("Content-Type: application/json")]
    public interface IWeatherForecastApi
    {
        [Get("/weatherforecasts/date/{date}")]
        Task<WeatherForecastDetails?> GetWeatherForecastByDateAsync([Query(Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")] DateTime date);
    }
}
