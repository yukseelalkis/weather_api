using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.model.Forecast
{
    public class ForecastResponse
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<ForecastItem> list { get; set; }
        public City city { get; set; }
    }
}