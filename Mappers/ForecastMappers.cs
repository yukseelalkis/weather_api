using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Dto;
using WeatherApi.model.Forecast;

namespace WeatherApi.Mappers
{
    public static  class ForecastMappers
    {
         public static List<ForecastDto> ToForecastDto(this ForecastResponse response)
        {
            return response.list
                .Where(x => x.dt_txt.EndsWith("12:00:00")) // Öğlen saatindeki verileri al
                .Take(7) // 7 günlük veri
                .Select(x => new ForecastDto
                {
                    Date = DateTime.Parse(x.dt_txt).ToString("yyyy-MM-dd"),
                    Temperature = Math.Round(x.main.temp - 273.15, 2),
                    WeatherMain = x.weather.FirstOrDefault()?.main ?? "Veri yok",
                    WeatherDescription = x.weather.FirstOrDefault()?.description ?? "Veri yok",
                    Icon = x.weather.FirstOrDefault()?.icon ?? "01d",
                    WindSpeed = x.wind.speed,
                    Humidity = x.main.humidity
                })
                .ToList();
        }
    }
    
}