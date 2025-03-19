using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Dto;
using WeatherApi.model;

namespace WeatherApi.Mappers
{
    public static class WeatherMappers
    {
    public static WeatherDto ToWeatherDto(this WeatherResponse response)
    {
        return new WeatherDto
        {
            CityName = response.name,
            Description = response.weather != null && response.weather.Count > 0 ? response.weather[0].description : "Veri yok",
            Temperature = Math.Round(response.main.temp - 273.15, 1), // Kelvin'den °C'ye çevir
            MinTemperature = Math.Round(response.main.temp_min - 273.15, 1),
            MaxTemperature = Math.Round(response.main.temp_max - 273.15, 1),
            WindSpeed = response.wind.speed,
            Humidity = response.main.humidity,
            Sunrise = UnixTimeToHour(response.sys.sunrise, response.timezone),
            Sunset = UnixTimeToHour(response.sys.sunset, response.timezone)
        };
    }

    private static string UnixTimeToHour(long unixTime, int timezone)
    {
        var time = DateTimeOffset.FromUnixTimeSeconds(unixTime).ToOffset(TimeSpan.FromSeconds(timezone));
        return time.ToString("HH:mm");
    }

    }
}