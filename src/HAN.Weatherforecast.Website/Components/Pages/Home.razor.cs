using HAN.Weatherforecast.Shared.Models;
using HAN.Weatherforecast.Website.Services;
using Microsoft.AspNetCore.Components;

namespace HAN.Weatherforecast.Website.Components.Pages;
public partial class Home
{
    [Inject]
    public IWeatherForecastApi ForecastService { get; set; } = null!;

    public IEnumerable<WeatherForecastSummary> WeatherForecasts { get; set; } = new List<WeatherForecastSummary>();

    public WeatherForecastDetails? SelectedWeatherForecast { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var weatherForecastForToday = await ForecastService.GetWeatherForecastByDateAsync(DateTime.Today);

        WeatherForecasts = new List<WeatherForecastSummary>
            {
                new WeatherForecastSummary
                {
                    Date = weatherForecastForToday.Date,
                    MaximumTemperature = weatherForecastForToday.MaximumTemperature,
                    WeatherType = weatherForecastForToday.WeatherType
                }
            };

        if (WeatherForecasts.Any())
        {
            await SelectWeatherForecastAsync(WeatherForecasts.First().Date);
        }
    }

    public async Task SelectWeatherForecastAsync(DateTime selectedDate)
    {
        SelectedWeatherForecast = await ForecastService.GetWeatherForecastByDateAsync(selectedDate);
    }
}
