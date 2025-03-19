using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Dto;
using WeatherApi.model;

namespace WeatherApi.Interface
{
    public interface IWeatherService
    {
        Task<WeatherDto>getWeather(string city);

    }
}