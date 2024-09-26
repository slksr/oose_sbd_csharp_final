using HAN.Weatherforecast.Service.Mappers;
using HAN.Weatherforecast.Service.Services;
using HAN.Weatherforecast.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HAN.Weatherforecast.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet("/api/weatherforecasts/date/{date}")]
    public WeatherForecastDetails GetWeatherForecastByDate(DateTime date)
    {
        var weatherForecast = _weatherForecastService.GetByDate(date);
        return weatherForecast.MapToDetails();
    }
}
