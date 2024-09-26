using HAN.Weatherforecast.Service.Entities;

namespace HAN.Weatherforecast.Service.Data.Repositories
{
    internal interface IWeatherForecastRepository
    {
        /// <summary>
        /// Gets a weather forecast for the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">The date of the weather forecast.</param>
        /// <returns>the weather forecast.</returns>
        WeatherForecast GetByDate(DateTime date);
    }
}
