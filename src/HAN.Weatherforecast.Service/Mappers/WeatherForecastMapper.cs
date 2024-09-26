﻿using HAN.Weatherforecast.Service.Entities;

namespace HAN.Weatherforecast.Service.Mappers
{
    internal static class WeatherForecastMapper
    {
        public static IEnumerable<Shared.Models.WeatherForecastSummary> MapToSummaries(this IEnumerable<WeatherForecast> source)
        {
            return source.Select(MapToSummary);
        }

        public static Shared.Models.WeatherForecastSummary MapToSummary(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecastSummary
            {
                Date = source.Date,
                WeatherType = source.WeatherType.MapTo<Shared.Models.WeatherType>(),
                MaximumTemperature = source.MaximumTemperature
            };
        }

        public static Shared.Models.WeatherForecastDetails MapToDetails(this WeatherForecast source)
        {
            return new Shared.Models.WeatherForecastDetails
            {
                Id = source.Id,
                Date = source.Date,
                WeatherType = source.WeatherType.MapTo<Shared.Models.WeatherType>(),
                MaximumTemperature = source.MaximumTemperature,
                MinimumTemperature = source.MinimumTemperature,
                NumberOfMillimetresRain = source.NumberOfMillimetresRain,
                PercentageOfChanceOfRain = source.PercentageOfChanceOfRain,
                WindDirection = source.WindDirection.MapTo<Shared.Models.WindDirection>(),
                WindStrength = source.WindStrength
            };
        }
    }
}
