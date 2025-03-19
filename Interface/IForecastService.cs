using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Dto;

namespace WeatherApi.Interface
{
    public interface IForecastService
    {
        Task<List<ForecastDto>> Get7DaysForecast(string city);

    }
}