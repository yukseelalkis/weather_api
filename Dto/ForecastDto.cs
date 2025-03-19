using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Dto
{
    public class ForecastDto
    {
        public string Date { get; set; }
        public double Temperature { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public string Icon { get; set; }
        public double WindSpeed { get; set; }
        public int Humidity { get; set; }
    }
}