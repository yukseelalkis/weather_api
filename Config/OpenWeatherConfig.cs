using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Config
{
    public class OpenWeatherConfig
    {
        public string BaseUrl { get; set; } = "https://api.openweathermap.org/data/2.5/";
        public string ApiKey { get; set; }
    }
}
