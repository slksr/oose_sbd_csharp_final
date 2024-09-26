using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.Weatherforecast.Shared.Models
{
    public class WeatherForecastSummary
    {
        public DateTime Date { get; set; }

        public WeatherType WeatherType { get; set; }

        /// <summary>
        /// Gets or sets the maximum temperature in °C.
        /// </summary>
        public int MaximumTemperature { get; set; }
    }
}
