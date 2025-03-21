using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Dto;

namespace WeatherApi.Interface
{
    public interface ICityService
    {
        Task<List<CitiesDto>> getCities();

    }
}