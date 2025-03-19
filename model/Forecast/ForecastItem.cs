using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.model.Forecast
{
    public class ForecastItem
    {
        public long dt { get; set; }
        public MainWeather main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; } // precipitation olasılığı
        public SysForecast sys { get; set; }
        public string dt_txt { get; set; }
    }
}