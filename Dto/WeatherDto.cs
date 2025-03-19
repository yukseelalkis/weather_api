using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Dto
{
    public class WeatherDto
    {
    public string CityName { get; set; }
    public string Description { get; set; }
    public double Temperature { get; set; }
    public double MinTemperature { get; set; }
    public double MaxTemperature { get; set; }
    public double WindSpeed { get; set; }
    public int Humidity { get; set; }
    public string Sunrise { get; set; }
    public string Sunset { get; set; }
    }
}