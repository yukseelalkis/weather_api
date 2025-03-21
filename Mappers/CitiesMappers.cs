using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Dto;
using WeatherApi.model.City;

namespace WeatherApi.Mappers
{
    public static class CitiesMappers
    {
        public static CitiesDto toCitiesDto(this CitiesModel citiesModel)
        {
            return new CitiesDto
            {
                CityName = citiesModel.Name
            };
        }

        public static List<CitiesDto> toCitiesDto(this IEnumerable<CitiesModel> citiesModels)
        {
            return citiesModels.Select(city => city.toCitiesDto()).ToList();
        }
    }
}
